from flask import Flask, jsonify
import cv2
import mediapipe as mp
import threading

app = Flask(__name__)
gesture_result = "none"

# MediaPipe setup
mp_hands = mp.solutions.hands
hands = mp_hands.Hands(static_image_mode=False, max_num_hands=1, min_detection_confidence=0.7)
mp_drawing = mp.solutions.drawing_utils

cap = cv2.VideoCapture(0)

def detect_hand():
    global gesture_result
    while True:
        success, image = cap.read()
        if not success:
            continue

        image = cv2.flip(image, 1)
        results = hands.process(cv2.cvtColor(image, cv2.COLOR_BGR2RGB))

        gesture_result = "none"

        if results.multi_hand_landmarks:
            hand = results.multi_hand_landmarks[0]
            lm = hand.landmark

            # === Finger Conditions ===

            # Thumb: Tip (4) is far right of IP (3) for right hand (flip x)
            thumb_open = abs(lm[4].x - lm[3].x) > 0.04  # large x gap

            # Index
            index_open = lm[8].y < lm[6].y
            # Middle
            middle_open = lm[12].y < lm[10].y
            # Ring
            ring_open = lm[16].y < lm[14].y
            # Pinky
            pinky_open = lm[20].y < lm[18].y

            fingers_extended = [thumb_open, index_open, middle_open, ring_open, pinky_open]
            num_extended = sum(fingers_extended)

            if num_extended == 5:
                gesture_result = "open_palm"
            else:
                gesture_result = "closed_palm"

        cv2.imshow('Hand Tracking', image)
        if cv2.waitKey(5) & 0xFF == 27:
            break

@app.route('/gesture', methods=['GET'])
def get_gesture():
    return jsonify({"gesture": gesture_result})

# Start detection in a thread
threading.Thread(target=detect_hand, daemon=True).start()

if __name__ == '__main__':
    app.run(host="0.0.0.0", port=5000)
