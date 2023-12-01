const googleAuthResponseMessage = (response: any) => {
  console.log(response);
}

const googleAuthErrorMessage = () => {
  console.log('Google Authentication Error')
}

const AuthService = {
  googleAuthResponseMessage,
  googleAuthErrorMessage
}

export default AuthService;