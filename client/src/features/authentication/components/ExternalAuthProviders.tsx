import {GoogleLogin} from "@react-oauth/google";
import AuthService from "../../../services/auth.service";
import React from "react";

export default function ExternalAuthProviders() {
  return (
    <div className={'external-providers mt-2 mb-2 d-flex justify-content-center'}>
      <div className={'external-providers-item mt-1'}>
        <GoogleLogin onSuccess={AuthService.googleAuthResponseMessage} onError={AuthService.googleAuthErrorMessage}/>
      </div>
    </div>
  )
}