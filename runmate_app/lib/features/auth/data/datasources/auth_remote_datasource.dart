import 'package:runmate_app/features/auth/data/dtos/auth_response_dto.dart';
import 'package:runmate_app/features/auth/data/dtos/login_request_dto.dart';
import 'package:runmate_app/features/auth/data/dtos/register_request_dto.dart';

abstract class AuthRemoteDataSource {
  Future<AuthResponseDto> login(LoginRequestDto request);

  Future<void> register(RegisterRequestDto request);
}
