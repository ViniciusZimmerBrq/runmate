import 'package:flutter/material.dart';
import 'package:runmate_app/app/theme/app_colors.dart';
import 'package:runmate_app/features/workouts/domain/entities/workout_summary.dart';

class WorkoutCard extends StatelessWidget {
  const WorkoutCard({
    super.key,
    required this.workout,
  });

  final WorkoutSummary workout;

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);

    return Container(
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: AppColors.card,
        borderRadius: BorderRadius.circular(20),
      ),
      child: Row(
        children: [
          Container(
            width: 44,
            height: 44,
            decoration: BoxDecoration(
              color: AppColors.lime.withValues(alpha: 0.35),
              borderRadius: BorderRadius.circular(14),
            ),
            child: const Icon(
              Icons.directions_run,
              color: AppColors.forest,
            ),
          ),
          const SizedBox(width: 12),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  workout.title,
                  style: theme.textTheme.titleMedium?.copyWith(
                    fontWeight: FontWeight.w700,
                  ),
                ),
                const SizedBox(height: 4),
                Text(
                  workout.dateLabel,
                  style: theme.textTheme.bodySmall?.copyWith(
                    color: AppColors.slate,
                  ),
                ),
              ],
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.end,
            children: [
              Text(
                workout.distanceLabel,
                style: theme.textTheme.titleMedium?.copyWith(
                  fontWeight: FontWeight.w800,
                ),
              ),
              const SizedBox(height: 4),
              Text(
                workout.paceLabel,
                style: theme.textTheme.bodySmall?.copyWith(
                  color: AppColors.slate,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
