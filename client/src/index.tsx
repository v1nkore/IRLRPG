import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import "@coreui/coreui/dist/css/coreui.min.css";

import { createRoot } from 'react-dom/client';
import {GoogleOAuthProvider} from "@react-oauth/google";
const container = document.getElementById('root');
const root = createRoot(container!);

const OAUTH_GOOGLE_CLIENT_ID = process.env.REACT_APP_OAUTH_GOOGLE_CLIENT_ID as string;
const OAUTH_GOOGLE_CLIENT_SECRET = process.env.REACT_APP_OAUTH_GOOGLE_CLIENT_SECRET as string;

root.render(
  <GoogleOAuthProvider clientId={OAUTH_GOOGLE_CLIENT_ID} key={OAUTH_GOOGLE_CLIENT_SECRET}>
    <React.StrictMode>
      <App/>
    </React.StrictMode>
  </GoogleOAuthProvider>);
