enum AuthStatus {
  idle,
  loading,
  success,
  error,
}

class AuthController {
  AuthStatus status = AuthStatus.idle;
}
