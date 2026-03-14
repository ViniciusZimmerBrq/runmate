import 'package:flutter/material.dart';
import 'package:runmate_app/app/theme/app_colors.dart';
import 'package:runmate_app/core/widgets/section_title.dart';
import 'package:runmate_app/features/dashboard/domain/entities/dashboard_metric.dart';
import 'package:runmate_app/features/dashboard/presentation/widgets/metric_card.dart';
import 'package:runmate_app/features/workouts/domain/entities/workout_summary.dart';
import 'package:runmate_app/features/workouts/presentation/widgets/workout_card.dart';

class DashboardPage extends StatelessWidget {
  const DashboardPage({super.key});

  static const metrics = [
    DashboardMetric(label: 'Distancia na semana', value: '18.4 km'),
    DashboardMetric(label: 'Treinos concluidos', value: '4'),
    DashboardMetric(label: 'Pace medio', value: '5:32/km'),
  ];

  static const recentWorkouts = [
    WorkoutSummary(
      title: 'Rodagem leve',
      dateLabel: 'Quarta, 12 de marco',
      distanceLabel: '5.0 km',
      paceLabel: '5:48/km',
    ),
    WorkoutSummary(
      title: 'Intervalado',
      dateLabel: 'Segunda, 10 de marco',
      distanceLabel: '7.2 km',
      paceLabel: '5:05/km',
    ),
    WorkoutSummary(
      title: 'Longao',
      dateLabel: 'Domingo, 9 de marco',
      distanceLabel: '12.0 km',
      paceLabel: '5:41/km',
    ),
  ];

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);

    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(20),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                padding: const EdgeInsets.all(24),
                decoration: BoxDecoration(
                  color: AppColors.forest,
                  borderRadius: BorderRadius.circular(28),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'RunMate',
                      style: theme.textTheme.titleLarge?.copyWith(
                        color: Colors.white,
                        fontWeight: FontWeight.w700,
                      ),
                    ),
                    const SizedBox(height: 12),
                    Text(
                      'Seu proximo treino e um progressivo de 6 km.',
                      style: theme.textTheme.headlineSmall?.copyWith(
                        color: Colors.white,
                        fontWeight: FontWeight.w800,
                      ),
                    ),
                    const SizedBox(height: 12),
                    Text(
                      'Voce ja concluiu 74% da sua meta semanal.',
                      style: theme.textTheme.bodyLarge?.copyWith(
                        color: Colors.white.withValues(alpha: 0.85),
                      ),
                    ),
                    const SizedBox(height: 20),
                    FilledButton(
                      onPressed: () {},
                      style: FilledButton.styleFrom(
                        backgroundColor: AppColors.lime,
                        foregroundColor: AppColors.forest,
                      ),
                      child: const Text('Registrar treino'),
                    ),
                  ],
                ),
              ),
              const SizedBox(height: 24),
              const SectionTitle(title: 'Resumo da semana'),
              const SizedBox(height: 12),
              GridView.builder(
                shrinkWrap: true,
                physics: const NeverScrollableScrollPhysics(),
                itemCount: metrics.length,
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 2,
                  mainAxisExtent: 110,
                  mainAxisSpacing: 12,
                  crossAxisSpacing: 12,
                ),
                itemBuilder: (context, index) {
                  if (index == metrics.length - 1) {
                    return GridTile(
                      child: MetricCard(metric: metrics[index]),
                    );
                  }

                  return MetricCard(metric: metrics[index]);
                },
              ),
              const SizedBox(height: 24),
              const SectionTitle(
                title: 'Ultimos treinos',
                actionLabel: 'Ver todos',
              ),
              const SizedBox(height: 12),
              for (final workout in recentWorkouts) ...[
                WorkoutCard(workout: workout),
                const SizedBox(height: 12),
              ],
            ],
          ),
        ),
      ),
    );
  }
}
