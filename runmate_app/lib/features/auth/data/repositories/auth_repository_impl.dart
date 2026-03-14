import 'package:runmate_app/features/auth/data/datasources/auth_remote_datasource.dart';
import 'package:runmate_app/features/auth/data/dtos/login_request_dto.dart';
import 'package:runmate_app/features/auth/data/dtos/register_request_dto.dart';
import 'package:runmate_app/features/auth/domain/entities/auth_session.dart';
import 'package:runmate_app/features/auth/domain/repositories/auth_repository.dart';

class AuthRepositoryImpl implements AuthRepository {
  const AuthRepositoryImpl(this._remoteDataSource);

  final AuthRemoteDataSource _remoteDataSource;

  @override
  Future<AuthSession> login({
    required String email,
    required String password,
  }) async {
    final response = await _remoteDataSource.login(
      LoginRequestDto(email: email, password: password),
    );

    return response.toEntity();
  }

  @override
  Future<void> register({
    required String name,
    required String email,
    required String password,
  }) {
    return _remoteDataSource.register(
      RegisterRequestDto(
        name: name,
        email: email,
        password: password,
      ),
    );
  }

  @override
  Future<void> logout() async {}
}
