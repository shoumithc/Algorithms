using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{

    public enum DaysEnum
    {
        Mon = 1,
        Tue = 2,
        Wed = 3,
        Thu = 4,
        Fri = 5,
        Sat = 6,
        Sun = 7
    }
    public class Interval
    {
       public int Minutes { get; set; }
       public bool IsEndOfDay { get; set; }
       public bool IsBeginningOfDay { get; set; }
    }

    public class DaySchedule{
    public DaysEnum day { get; set; }
        public List<Interval> FreeIntervals { get; set; }
        public List<string> meetings { get; set; }
    
}

    public class DayShortMeeting{
        public DaysEnum day { get; set; }
        public string DayName { get; set; }
        public string MeetingSchedule { get; set; }
    }

    class JamesSleep
    {
        public int solution(string S)
        {
            int HighestMinutes = 0;
            var daySchedulesList = GetDaySchedules(S);
            List<int> allTimeSlots = new List<int>();
            var sortedSchedulesList = daySchedulesList.OrderBy(o => o.day).ToList();
            sortedSchedulesList.Add(sortedSchedulesList.First());
            for (var index = 0; index < sortedSchedulesList.Count-1; index++)
            {
                var daySchedule1 = sortedSchedulesList[index];
                var daySchedule2 = sortedSchedulesList[index+1];
                CalculateFreeIntervals(daySchedule1);
                allTimeSlots.AddRange(daySchedule1.FreeIntervals.Where(x=>!x.IsEndOfDay && !x.IsBeginningOfDay).Select(x=>x.Minutes));
                CalculateFreeIntervals(daySchedule2);
                allTimeSlots.Add(daySchedule1.FreeIntervals.FirstOrDefault(x=>x.IsEndOfDay).Minutes+daySchedule2.FreeIntervals.FirstOrDefault(x=>x.IsBeginningOfDay).Minutes);
            }
            HighestMinutes = allTimeSlots.OrderBy(x => x).Last();
            return HighestMinutes;
        }

        public void CalculateFreeIntervals(DaySchedule daySchedule)
        {
            daySchedule.meetings.Sort();
            daySchedule.FreeIntervals=new List<Interval>();
            var meetingSlotFirst = daySchedule.meetings.FirstOrDefault();
            if (meetingSlotFirst != null)
            {
                var timeSlot1 = meetingSlotFirst.Split("-");
                Interval interval = new Interval
                {
                    Minutes = GetTimeInMinutes(timeSlot1[0]),
                    IsBeginningOfDay = true
                };

                var meetingSlotLast = daySchedule.meetings.Last();
                var timeSlotLast = meetingSlotLast.Split("-");
                Interval intervalLast = new Interval
                {
                    Minutes = 24*60 - GetTimeInMinutes(timeSlotLast[1]),
                    IsEndOfDay = true
                };
                daySchedule.FreeIntervals.Add(interval);
                daySchedule.FreeIntervals.Add(intervalLast);

            }
            for (var index = 0; index < daySchedule.meetings.Count-1; index++)
            {
                var meetingSlot1 = daySchedule.meetings[index];
                var meetingSlot2 = daySchedule.meetings[index+1];
                int duration = GetMinutesForTime(meetingSlot1, meetingSlot2);
                Interval interval = new Interval
                {
                    Minutes = duration
                };
                daySchedule.FreeIntervals.Add(interval);
            }
        }

        public int GetMinutesForTime(string time1, string time2)
        {
            int minutes = 0;
            var timeSlot1 = time1.Split("-");
            var timeSlot2 = time2.Split("-");
            return GetTimeInMinutes(timeSlot2[0])-GetTimeInMinutes(timeSlot1[1]);
        }

        public int GetTimeInMinutes(string timeSlot)
        {
            var time = timeSlot.Split(":");
            return Convert.ToInt32(time[0]) * 60 + Convert.ToInt32(time[1]);
        }

        public List<DaySchedule> GetDaySchedules(string S)
        {
            List<DaySchedule> daySchedules = new List<DaySchedule>();
            List<DayShortMeeting> dayShortSchedules = new List<DayShortMeeting>();
            string[] lines = S.Split(
                new[] {"\n" },
                StringSplitOptions.None
            );
            foreach (var schedule in lines)
            {
                var dayShortSchedule = new DayShortMeeting
                {
                    DayName = schedule.Substring(0, 3),
                    day = (DaysEnum)Enum.Parse(typeof(DaysEnum), schedule.Substring(0, 3), true),
                    MeetingSchedule = schedule
                };
                dayShortSchedules.Add(dayShortSchedule);
            }
            daySchedules = dayShortSchedules.GroupBy(x=> x.day).Select(grp =>
                new DaySchedule
                {
                    day = grp.Key,
                    meetings = grp.Select(x=>x.MeetingSchedule.Substring(3, x.MeetingSchedule.Length-3)).ToList(),
                }).ToList();
            return daySchedules;
        }


        //public static void Main()
        //{
        //    string meetingResults =
        //        "Sun 10:00-20:00\nFri 05:00-10:00\nFri 16:30-23:50\nSat 10:00-24:00\nSun 01:00-04:00\nSat 02:00-06:00\nTue 03:30-18:15\nTue 19:00-20:00\nWed 04:25-15:14\nWed 15:14-22:40\nThu 00:00-23:59\nMon 05:00-13:00\nMon 15:00-21:00";            
        //    JamesSleep r = new JamesSleep();
        //    int result = r.solution(meetingResults);
        //}
    }
}
