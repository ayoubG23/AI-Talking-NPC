from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

# Request format from Unity
class ChatRequest(BaseModel):
    message: str

# API endpoint
@app.get("/")
async def root():
    return {"message": "Welcome to the AI Tutor API!"}

@app.post("/chat")
async def chat(data: ChatRequest):

    user_message = data.message

    #  fake response logic based on user message

    if "hello" in user_message.lower():
        answer = "Hello student!"
    
    elif "language" in user_message.lower():
        answer = "VR can improve language learning."

    else:
        answer = "I am your AI tutor."

    return {
        "response": answer
    }