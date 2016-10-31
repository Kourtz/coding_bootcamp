from flask import Flask, url_for, flash, send_from_directory, request, redirect, render_template
from forms import ContactForm
from flask import session
import os
"""
from flask_wtf import Form
from wtforms import TextField, SubmitField, PasswordField
"""
app = Flask(__name__)
app.secret_key = 'random string'

@app.route('/static/css/stylesheet.css')
def serve_static_css(filename):
    root_dir = os.path.dirname(os.getcwd())
    return send_from_directory(os.path.join(root_dir, 'static', 'css'), filename)

@app.route('/')
def index():
    return render_template('index.html')


@app.route('/new', methods = ['GET', 'POST'])
def new():
    if (request.method == 'POST'):
        if (not request.form['name'] or not request.form['surname'] \
                or not request.form['email'] or not request.form['password']):
            flash('Please fill all the fields.', 'error')
        else:
            session['email'] = request.form['email']
            return login()
    return render_template('new.html')


@app.route('/login', methods=['POST'])
def login():
    if 'email' in session:
        email = session['email']
        return 'Hi ' + email + '! Welcome to our bookstore<br>' + \
               "<b><a href = '/logout'>click here if you want to log out</a></b>"
    return "You are not logged in <br><a href = '/login'></b>" + \
      "click here to log in</b></a>"


@app.route('/logout')
def logout():
   # remove the name from the session if it is there
   session.pop('email', None)
   return redirect(url_for('index'))


if __name__ == '__main__':
   app.run(debug = True)

   
