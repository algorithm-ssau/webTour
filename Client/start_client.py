from flask import Flask, render_template, jsonify
import requests
import json

app = Flask(__name__)

@app.route('/')
def home():
    return render_template("main.html")

if __name__ == "__main__":
    app.run()