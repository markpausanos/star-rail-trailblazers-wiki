import React, { useState } from "react";

export const SignUp = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    
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
                    <button type="submit">Sign In</button>
                </form>
                <p>Already have an account? <a href="/" onClick={() => props.onFormSwitch('login')}>Sign in</a>.</p>
            </div>
        </div>
    )
}

export default SignUp;