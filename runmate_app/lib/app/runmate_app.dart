import 'package:flutter/material.dart';
import 'package:runmate_app/app/theme/app_theme.dart';
import 'package:runmate_app/features/dashboard/presentation/pages/dashboard_page.dart';

class RunMateApp extends StatelessWidget {
  const RunMateApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'RunMate',
      debugShowCheckedModeBanner: false,
      theme: AppTheme.light(),
      home: const DashboardPage(),
    );
  }
}
