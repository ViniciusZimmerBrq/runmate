import 'package:flutter/material.dart';
import 'package:runmate_app/app/theme/app_colors.dart';
import 'package:runmate_app/features/dashboard/domain/entities/dashboard_metric.dart';

class MetricCard extends StatelessWidget {
  const MetricCard({
    super.key,
    required this.metric,
  });

  final DashboardMetric metric;

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);

    return Container(
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: AppColors.card,
        borderRadius: BorderRadius.circular(20),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            metric.value,
            style: theme.textTheme.headlineSmall?.copyWith(
              fontWeight: FontWeight.w800,
            ),
          ),
          const SizedBox(height: 8),
          Text(
            metric.label,
            style: theme.textTheme.bodyMedium?.copyWith(
              color: AppColors.slate,
            ),
          ),
        ],
      ),
    );
  }
}
