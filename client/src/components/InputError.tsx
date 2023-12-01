import React from "react";

interface InputErrorComponentProps {
    visibilityCondition: boolean;
    message: string;
}

export default function InputError(inputErrorComponentProps: InputErrorComponentProps) {
    return (
        <div>
            {
                inputErrorComponentProps.visibilityCondition &&
                <div className="text-danger input-validation__block mb-2">
                    {inputErrorComponentProps.message}
                </div>
            }
        </div>
    )
}