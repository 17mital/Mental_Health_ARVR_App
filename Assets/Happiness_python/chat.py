from flask import Flask, request
from flask_cors import CORS

app = Flask(__name__)
CORS(app)  # Allow Unity to talk to this server

@app.route('/analyze', methods=['POST'])
def analyze():
    user_msg = request.form.get('message').lower()

    # Basic NLP-like keyword checks
    if any(word in user_msg for word in ["sad", "depressed", "unhappy", "crying"]):
        response = "I'm really sorry you're feeling this way. You're not alone. Want to try a mood-lifting activity or talk more about it?"
    
    elif any(word in user_msg for word in ["angry", "mad", "frustrated", "annoyed"]):
        response = "I understand that anger can be overwhelming. Would you like to try a short breathing session or calming exercise?"

    elif any(word in user_msg for word in ["anxious", "nervous", "worried", "scared"]):
        response = "Anxiety can be tough. You're doing great by reaching out. Would grounding techniques help right now?"

    elif any(word in user_msg for word in ["lonely", "alone", "isolated"]):
        response = "Feeling alone can be hard. I'm here with you. Want to try a journal prompt or hear an inspiring quote?"

    elif any(word in user_msg for word in ["happy", "great", "awesome", "good"]):
        response = "That's wonderful to hear! Would you like to record this positive moment or share what made your day better?"

    elif any(word in user_msg for word in ["help", "support", "talk", "need someone"]):
        response = "Of course — I’m here for you. Tell me what's on your mind, or I can connect you to some professional resources."

    # Casual Greeting and Conversation
    elif any(word in user_msg for word in ["hello", "hi", "hey", "greetings"]):
        response = "Hello there! How’s your day going so far?"

    elif any(word in user_msg for word in ["how", "are", "you"]):
        response = "I'm doing well, thank you for asking! How about you?"

    elif any(word in user_msg for word in ["good", "fine", "well"]):
        response = "Glad to hear you're doing well! Anything on your mind today?"

    elif any(word in user_msg for word in ["what's up", "how's it going", "what's new"]):
        response = "Not much, just here to chat with you! How are you feeling today?"

    elif any(word in user_msg for word in ["how's life", "how's everything"]):
        response = "Life's good! Just here to help you out. How's everything with you?"

    elif any(word in user_msg for word in ["hey there", "yo", "hi there"]):
        response = "Hey there! What’s on your mind today?"

    # Casual Farewell and Checking In
    elif any(word in user_msg for word in ["bye", "goodbye", "see you", "take care"]):
        response = "Goodbye for now! Take care of yourself, and remember, I'm always here if you need to talk."

    elif any(word in user_msg for word in ["see you later", "catch you later"]):
        response = "Catch you later! Remember, you're never alone. Reach out anytime."

    elif any(word in user_msg for word in ["talk soon", "speak later"]):
        response = "Talk soon! I’m just a message away whenever you need support."

    elif any(word in user_msg for word in ["thank you", "thanks"]):
        response = "You're welcome! I’m happy to be here for you."

    elif any(word in user_msg for word in ["have a good day", "enjoy your day"]):
        response = "I hope you have a wonderful day ahead! Remember, I’m always here if you need to talk."

    elif any(word in user_msg for word in ["good night", "sleep well"]):
        response = "Good night! Rest well, and take care of yourself. I’ll be here whenever you’re ready to chat."

    # Encouraging Responses
    elif any(word in user_msg for word in ["tired", "exhausted", "drained"]):
        response = "It sounds like you’ve been through a lot. Taking time for yourself to rest and recharge might help. Would you like some relaxation techniques?"

    elif any(word in user_msg for word in ["stressed", "overwhelmed", "busy"]):
        response = "It’s okay to feel overwhelmed sometimes. Would you like to try a quick mindfulness exercise or talk through what’s been stressing you out?"

    elif any(word in user_msg for word in ["hope", "believe", "strength"]):
        response = "It’s so great that you’re holding onto hope! Would you like me to share a motivational quote with you?"

    elif any(word in user_msg for word in ["can’t", "struggling", "difficult"]):
        response = "I know things feel tough right now, but you're doing the best you can. Want to talk more about what's on your mind?"

    elif any(word in user_msg for word in ["encourage", "motivate", "positive"]):
        response = "You’ve got this! Keep pushing forward, and take it one step at a time. I’m here to support you in any way I can."

    else:
        response = "Thanks for sharing that. I'm here to talk anytime. Want to try a relaxing activity or continue chatting?"

    return response

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
