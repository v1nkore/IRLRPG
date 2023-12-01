import {CButton} from "@coreui/react";
import Navbar from "./components/Navbar";
import React from "react";
import AuthForm from "./features/authentication/components/AuthForm";

function App() {
    return (
        <div className="login-form app">
            <AuthForm/>
        </div>
    )
}

export default App;