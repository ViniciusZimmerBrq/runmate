import 'package:runmate_app/features/auth/domain/entities/auth_session.dart';

class AuthResponseDto {
  const AuthResponseDto({
    required this.accessToken,
    required this.expiresInSeconds,
    required this.userId,
    required this.userName,
    required this.email,
  });

  final String accessToken;
  final int expiresInSeconds;
  final String userId;
  final String userName;
  final String email;

  factory AuthResponseDto.fromJson(Map<String, dynamic> json) {
    final user = (json['user'] as Map<String, dynamic>? ?? <String, dynamic>{});

    return AuthResponseDto(
      accessToken: json['accessToken'] as String? ?? '',
      expiresInSeconds: json['expiresInSeconds'] as int? ?? 0,
      userId: user['id'] as String? ?? '',
      userName: user['name'] as String? ?? '',
      email: user['email'] as String? ?? '',
    );
  }

  AuthSession toEntity() {
    return AuthSession(
      accessToken: accessToken,
      expiresInSeconds: expiresInSeconds,
      userId: userId,
      userName: userName,
      email: email,
    );
  }
}
