from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

# Request model from Unity
class ChatRequest(BaseModel):
    message: str

@app.get("/")
async def root():
    return {
        "message": "AI Tutor API Running"
    }

@app.post("/chat")
async def chat(data: ChatRequest):

    user_message = data.message.lower()

    # Simple AI dialogue logic

    if "hello" in user_message:
        answer = "Hello student!"

    elif "language" in user_message:
        answer = "VR improves immersive language learning."

    elif "unity" in user_message:
        answer = "Unity is useful for VR simulations."

    else:
        answer = "I am your AI tutor."

    return {
        "response": answer
    }