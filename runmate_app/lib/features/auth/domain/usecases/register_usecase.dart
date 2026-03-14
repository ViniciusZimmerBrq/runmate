import 'package:runmate_app/features/auth/domain/repositories/auth_repository.dart';

class RegisterUseCase {
  const RegisterUseCase(this._repository);

  final AuthRepository _repository;

  Future<void> call({
    required String name,
    required String email,
    required String password,
  }) {
    return _repository.register(
      name: name,
      email: email,
      password: password,
    );
  }
}
