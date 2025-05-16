from flask import Flask, request, jsonify
import base64
import cv2
import numpy as np
from PIL import Image
import io
import mediapipe as mp

app = Flask(__name__)

# Load MediaPipe FaceMesh
mp_face_mesh = mp.solutions.face_mesh
face_mesh = mp_face_mesh.FaceMesh(static_image_mode=True)

@app.route('/detect_emotion', methods=['POST'])
def detect_emotion():
    data = request.get_json()
    image_data = base64.b64decode(data['image'])

    # Convert to OpenCV image
    image = Image.open(io.BytesIO(image_data)).convert('RGB')
    img_np = np.array(image)
    img_np = cv2.cvtColor(img_np, cv2.COLOR_RGB2BGR)

    # Run face mesh
    results = face_mesh.process(cv2.cvtColor(img_np, cv2.COLOR_BGR2RGB))

    if not results.multi_face_landmarks:
        return jsonify({'emotion': "No Face Detected 😶"})

    # Extract landmarks
    landmarks = []
    for lm in results.multi_face_landmarks[0].landmark:
        landmarks.extend([lm.x, lm.y, lm.z])

    # Dummy classifier based on mouth openness (y diff between lips)
    top_lip = results.multi_face_landmarks[0].landmark[13]  # upper lip
    bottom_lip = results.multi_face_landmarks[0].landmark[14]  # lower lip
    mouth_openness = abs(bottom_lip.y - top_lip.y)

    if mouth_openness > 0.03:
        emotion = "Happy 😊"
    elif mouth_openness < 0.015:
        emotion = "Sad "
    else:
        emotion = "Neutral "

    return jsonify({'emotion': emotion})

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
