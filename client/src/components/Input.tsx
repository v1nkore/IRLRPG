import React from "react";
import {firstLetterToUpperCase} from "../utils";

interface InputComponentProps {
    id: string;
    name: string;
    value?: string;
    type: string;
    placeholder?: string;
    disabled?: boolean;
    label: string;
    onChange?:  React.ChangeEventHandler<HTMLInputElement> | undefined;
    required?: boolean;
}

export default function Input({id, name, label, value, type, placeholder, disabled, onChange, required}: InputComponentProps) {
    return (
        <div className="label-input-pair__block">
            <label htmlFor={id}>
                {firstLetterToUpperCase(label)}
            </label>
            <input onChange={onChange} name={name} id={id} type={type} value={value} placeholder={placeholder} disabled={disabled} required={required}/>
        </div>
    )
}