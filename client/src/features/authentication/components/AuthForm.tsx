import React, {FormEvent, useState} from "react";
import "../styles/auth.css";
import Input from "../../../components/Input";
import InputError from "../../../components/InputError";
import {GoogleLogin} from "@react-oauth/google";
import AuthService from "../../../services/auth.service";
import ExternalAuthProviders from "./ExternalAuthProviders";

export default function AuthForm() {
    const defaultFormState = {
        name: '',
        email: '',
        password: '',
        repeatedPassword: '',
    }
    const [formState, setFormState] = useState(defaultFormState);
    const [submitted, setSubmitted] = useState(false);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setFormState({
            ...formState,
            [`${event.currentTarget.name!}`]: [event.currentTarget.value]
        })
        setSubmitted(false);
    }

    const [authType, setAuthType] = useState("login");
    const handleOnClick = (event: React.MouseEvent, text: string) => {
        if (text !== authType) {
            setAuthType(text);
            setSubmitted(false);
            setFormState(defaultFormState)
        }
    };

    const handleOnSubmit = (event: FormEvent) => {
        event.preventDefault();

        setSubmitted(true)
    };

    return (
        <div id="auth-form">

            <div className="form-group">
                {
                    authType === 'login' &&
                    <div className="form-group-login">
                        <h1 className="auth-header">Login</h1>
                        <form onSubmit={handleOnSubmit}>
                            <Input
                                onChange={handleInputChange}
                                value={formState.email}
                                type="text" id="email" name="email" label="email" placeholder="me@example.com"/>
                            <InputError
                                visibilityCondition={!formState.email && submitted}
                                message={'Email field is required'}/>

                            <Input
                                onChange={handleInputChange}
                                value={formState.password}
                                type="password" id="password" name="password" label="password" placeholder="•••••••"/>
                            <InputError
                                visibilityCondition={!formState.password && submitted}
                                message={'Password field is required'}/>

                            <div className="submit-btn__block text-center w-75 m-auto">
                                <button type="submit" className="w-100 btn btn-primary">Submit</button>
                            </div>

                            <ExternalAuthProviders></ExternalAuthProviders>

                            <div className="auth-btn__block">
                                <button type="button" className="btn btn-outline-danger auth-switch-btn" onClick={(e) => handleOnClick(e, ('signup'))}>Still don't have an account?</button>
                            </div>
                        </form>
                    </div>
                }

                {
                    authType === 'signup' &&
                    <div className="form-group-signup">
                        <h1 className="auth-header">Sign up</h1>
                        <form onSubmit={handleOnSubmit}>
                            <Input
                                onChange={handleInputChange}
                                value={formState.name}
                                type="text" id="name" name="name" label="name" />
                            <InputError
                                visibilityCondition={!formState.name && submitted}
                                message={'Name field is required'}/>

                            <Input
                                onChange={handleInputChange}
                                value={formState.email}
                                type="text" id="email" name="email" label="email" placeholder="me@example.com"/>
                            <InputError
                                visibilityCondition={!formState.email && submitted}
                                message={'Email field is required'}/>

                            <Input
                                onChange={handleInputChange}
                                value={formState.password}
                                type="password" id="password" name="password" label="password" placeholder="•••••••"/>
                            <InputError
                                visibilityCondition={!formState.password && submitted}
                                message={'Password field is required'}/>

                            <Input
                                onChange={handleInputChange}
                                value={formState.repeatedPassword}
                                type="password" id="repeatedPassword" name="repeatedPassword" label="repeatedPassword" placeholder="•••••••"/>
                            <InputError
                                visibilityCondition={!formState.repeatedPassword && submitted}
                                message={'Repeated password field is required'}/>

                            <div className="submit-btn__block text-center w-75 m-auto">
                                <button type="submit" className="w-100 btn btn-primary">Submit</button>
                            </div>

                            <ExternalAuthProviders></ExternalAuthProviders>

                            <div className="auth-btn__block">
                                <button type="button" className="btn btn-outline-success auth-switch-btn" onClick={(e) => handleOnClick(e, ('login'))}>Already have an account?</button>
                            </div>
                        </form>
                    </div>
                }

            </div>
        </div>
    );
}
