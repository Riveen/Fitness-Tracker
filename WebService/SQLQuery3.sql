declare @date1 date = '2023-07-24 02:05:09.6100';
declare @end_date date = DATEADD(day, 2 - DATEPART(WEEKDAY, @date1), @date1);
declare @weekno int;
declare @weekno2 int;
PRINT @weekno;
IF @date1 = @end_date 
BEGIN
	SET @weekno = (SELECT MAX(DISTINCT week) FROM workouts)
	IF (@weekno is not null)
		INSERT INTO [dbo].[tmp_weeklydata] (week, date, workout, used_weight, sets, reps, duration)
		SELECT week, date, workout, used_weight, sets, reps, duration FROM [dbo].[workouts]
		WHERE week = @weekno
		PRINT @weekno;
		INSERT INTO [dbo].[weeklydata] (week, date, workout, used_weight, sets, reps, duration)
		SELECT week, date, workout, used_weight, sets, reps, duration FROM [dbo].[tmp_weeklydata]
		SET @weekno2 = (SELECT COUNT(*) FROM tmp_weeklydata)
		IF (@weekno2 is not null)
			DELETE FROM tmp_weeklydata where week = @weekno
		PRINT 'End of the Week!' ;
END
ELSE 
	PRINT 'Not the End of the Week!' ;
