.PHONY: dev backend flutter test backend-test flutter-test

# Run backend and Flutter app simultaneously
dev:
	@echo "Starting backend on :5000 and Flutter app..."
	@cd runmate_backend && dotnet run --project src/RunMate.Api &
	@cd runmate_app && flutter run \
		--dart-define=API_BASE_URL=http://localhost:5000 \
		--dart-define=APP_ENV=dev

# Run only the .NET backend
backend:
	cd runmate_backend && dotnet run --project src/RunMate.Api

# Run only the Flutter app
flutter:
	cd runmate_app && flutter run \
		--dart-define=API_BASE_URL=http://localhost:5000 \
		--dart-define=APP_ENV=dev

# Run all tests (backend then Flutter)
test: backend-test flutter-test

# Run only .NET tests
backend-test:
	cd runmate_backend && dotnet test

# Run only Flutter tests
flutter-test:
	cd runmate_app && flutter test
