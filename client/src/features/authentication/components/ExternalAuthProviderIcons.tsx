import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faFacebookF, faGithub, faGoogle} from "@fortawesome/free-brands-svg-icons";
import React from "react";

export default function ExternalAuthProviderIcons(){
  const googleOAuthResponseMessage = (response: any) => {
    console.log(response);
  }

  const googleOAuthErrorMessage = () => {
    console.log('Error');
  }

    return (
        <div className="w-100 my-3 external-providers__block d-inline-flex justify-content-around">
            <div className="external-provider__item">
                <FontAwesomeIcon icon={faGoogle} size={"2xl"}/>
            </div>
            <div className="external-provider__item">
                <FontAwesomeIcon icon={faFacebookF} size={"2xl"}/>
            </div>
            <div className="external-provider__item">
                <FontAwesomeIcon icon={faGithub} size={"2xl"}/>
            </div>
        </div>
    )
}