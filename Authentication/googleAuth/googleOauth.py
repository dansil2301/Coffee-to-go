import json
import os
from flask import Flask, render_template, jsonify, request

app = Flask("Google Login App")
app.secret_key = "very secret"


@app.route("/")
def index():
    return render_template('index.html')


@app.route("/save_user_inf", methods=['POST'])
def save_user_inf():
    print("hello")
    print(request.form)

    user_id = request.form["user_id"]
    email = request.form["email"]
    display_name = request.form["displayName"]

    with open("../current_user/current_user.json", "w") as user:
        user_inf = {"id": user_id, "email": email, "displayName": display_name}
        json.dump(user_inf, user)

    return jsonify({"success": True})


@app.route('/shutdown', methods=['POST'])
def shutdown():
    os.kill(os.getpid(), 9)
    return 'Server shutting down...'


@app.route("/callback")
def callback():
    return render_template('callback.html')


if __name__ == "__main__":
    app.run(debug=True)
