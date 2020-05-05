using System;
using System.Collections.Generic;
using System.Linq;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;
using CompanyName.MyMeetings.Modules.Meetings.Domain.MeetingGroups;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Meetings;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Meetings.CreateMeeting
{
    public class CreateMeetingCommand : CommandBase
    {
        public CreateMeetingCommand(Guid meetingGroupId, string title, DateTime termStartDate, DateTime termEndDate, string description, string meetingLocationName, string meetingLocationAddress, string meetingLocationPostalCode, string meetingLocationCity, int? attendeesLimit, int guestsLimit, DateTime? rsvpTermStartDate, DateTime? rsvpTermEndDate, decimal? eventFeeValue, string eventFeeCurrency, List<Guid> hostMemberIds)
        {
            MeetingGroupId = new MeetingGroupId(meetingGroupId);
            Title = title;
            MeetingTerm = MeetingTerm.CreateNewBetweenDates(termStartDate, termEndDate);
            Description = description;
            MeetingLocation = MeetingLocation.CreateNew(meetingLocationName, meetingLocationAddress, meetingLocationPostalCode, meetingLocationCity);
            AttendeesLimit = attendeesLimit;
            GuestsLimit = guestsLimit;
            RSVPTerm = Term.CreateNewBetweenDates(rsvpTermStartDate, rsvpTermEndDate);
            EventFee = eventFeeValue.HasValue ? MoneyValue.Of(eventFeeValue.Value, eventFeeCurrency) : MoneyValue.Undefined;
            HostMemberIds = hostMemberIds.Select(x => new MemberId(x));
        }

        public MeetingGroupId MeetingGroupId { get; }

        public string Title { get; }

        public MeetingTerm MeetingTerm { get; }

        public string Description { get; }

        public MeetingLocation MeetingLocation { get; }

        public int? AttendeesLimit { get; }

        public int GuestsLimit { get; }

        public Term RSVPTerm { get; }

        public MoneyValue EventFee { get; }

        public IEnumerable<MemberId> HostMemberIds { get; }
    }
}