.PHONY: dev backend flutter test backend-test flutter-test \
        issues workflow workflow-timeline workflow-reset

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

# ──────────────────────────────────────────────────────────────────────────────
# Multi-agent workflow (Claude CLI sequential pipeline)
# ──────────────────────────────────────────────────────────────────────────────

## Lista todas as issues do projeto com número, status e área
issues:
	python3 -m runmate_ops_swarms.cli ready

## make workflow ISSUE=42       – roda o pipeline completo da issue
workflow:
ifndef ISSUE
	$(error ISSUE não definido. Use: make workflow ISSUE=42)
endif
	@echo "▶ Iniciando workflow para issue #$(ISSUE)..."
	python3 -m runmate_ops_swarms.cli workflow $(ISSUE)

## make workflow-timeline ISSUE=42 – exibe o status do fluxo da issue
workflow-timeline:
ifndef ISSUE
	$(error ISSUE não definido. Use: make workflow-timeline ISSUE=42)
endif
	python3 -m runmate_ops_swarms.cli timeline $(ISSUE)

## make workflow-reset ISSUE=42 – reseta o estado local da issue
workflow-reset:
ifndef ISSUE
	$(error ISSUE não definido. Use: make workflow-reset ISSUE=42)
endif
	python3 -m runmate_ops_swarms.cli reset $(ISSUE)
