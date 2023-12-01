import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import React from "react";
import {faBrain} from "@fortawesome/free-solid-svg-icons";
import {CButton} from "@coreui/react";

// const inlineFormStyles = {
//     background: '#f6f5f7;'
// }

function Navbar() {
    return (
        <div className={"mt-3 container-fluid"}>
            <div className="navbar-block">
                <nav className="navbar navbar-light">
                    <a className="navbar-brand">
                        <FontAwesomeIcon size={"2x"} icon={faBrain} />
                    </a>
                    <a className="navbar-brand">IRLRPG</a>
                    <form className="form-inline">
                        <CButton className="btn btn-secondary m-2 my-sm-0" type="submit">Login</CButton>
                        <CButton className="btn btn-primary m-2 my-sm-0" type="submit">Sign up</CButton>
                    </form>
                </nav>
            </div>
        </div>
    );
}

export default Navbar;