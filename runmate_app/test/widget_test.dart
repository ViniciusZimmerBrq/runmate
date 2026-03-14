import 'package:flutter_test/flutter_test.dart';
import 'package:runmate_app/app/runmate_app.dart';

void main() {
  testWidgets('renders dashboard shell', (WidgetTester tester) async {
    await tester.pumpWidget(const RunMateApp());

    expect(find.text('RunMate'), findsOneWidget);
    expect(find.text('Resumo da semana'), findsOneWidget);
    expect(find.text('Ultimos treinos'), findsOneWidget);
    expect(find.text('Registrar treino'), findsOneWidget);
  });
}
