using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Meetings;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Meetings.AddMeetingAttendee
{
    public class AddMeetingAttendeeCommand : CommandBase
    {

        public MeetingId MeetingId { get; }

        public int GuestsNumber { get; }


        public AddMeetingAttendeeCommand(Guid meetingId, int guestsNumber)
        {
            MeetingId = new MeetingId(meetingId);
            GuestsNumber = guestsNumber;
        }
    }
}