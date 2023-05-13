import React, { useState } from "react";
import { useNavigate } from "react-router";
import "./Login.css";

export const SignUp = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(username, password, confirmPassword);
    }

    return (
        <div className="background-image">
            <div className="container1">
                <h2>Sign Up</h2>
                <form onSubmit={handleSubmit}>
                    <label htmlFor="username">Username</label>
                    <input value={username} onChange={(e) => setUsername(e.target.value)} type="username" placeholder="Enter username" id="usernameid" name="username" />
                    <br />
                    <label htmlFor="password">Password</label>
                    <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="Enter password" id="passwordid" name="password" />
                    <br />
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} type="password" placeholder="Confirm password" id="confirmPasswordid" name="confirmPassword" />
                    <br />
                    <button className= "button-signin" type="submit">Sign In</button>
                </form>

                <p>Already have an account? 
                    <button className="link-button" onClick={() => navigate('/')}>Login</button>.
                </p>
            </div>
        </div>
    )
}

export default SignUp;