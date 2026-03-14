import 'package:runmate_app/features/auth/domain/entities/auth_session.dart';

abstract class AuthRepository {
  Future<AuthSession> login({
    required String email,
    required String password,
  });

  Future<void> register({
    required String name,
    required String email,
    required String password,
  });

  Future<void> logout();
}
