using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LaSpruca.KNIDotNet.Response {
    /// <summary>
    /// The result of send a request to get the notices
    /// </summary>
    [Serializable, XmlRoot(Namespace = "", ElementName = "NoticesResults")]
    public struct NoticesResponse {
        [XmlAttribute(AttributeName = "apiversion")]
        public string ApiVersion;

        [XmlAttribute(AttributeName = "portalversion")]
        public string PortalVersion;
        
        /// <summary>
        /// Access level granted by the key provided
        /// </summary>
        [XmlElement(ElementName = "AccessLevel")]
        public string AccessLevel;
        
        /// <summary>
        /// If there were any errors, 0 if there were none
        /// </summary>
        [XmlElement(ElementName = "ErrorCode")]
        public int ErrorCode;
        
        /// <summary>
        /// The actual error
        /// </summary>
        [XmlElement(ElementName = "Error", IsNullable = true)]
        public string Error;

        [XmlElement(ElementName = "NoticeDate", IsNullable = true)]
        public string NoticesDate;

        [XmlElement(ElementName = "NumberRecords")]
        public int NumberOfNotices;
        
        /// <summary>
        /// All the meeting notices
        /// </summary>
        [XmlElement(ElementName = "MeetingNotices", IsNullable = true)]
        public MeetingNotices? MeetingNotices;
        
        /// <summary>
        /// All the general notices
        /// </summary>
        [XmlElement(ElementName = "GeneralNotices", IsNullable = true)]
        public GeneralNotices? GeneralNotices;

        public override string ToString() {
            return $"{nameof(ApiVersion)}: {ApiVersion}, {nameof(PortalVersion)}: {PortalVersion}, {nameof(AccessLevel)}: {AccessLevel}, {nameof(ErrorCode)}: {ErrorCode}, {nameof(Error)}: {Error}, {nameof(NoticesDate)}: {NoticesDate}, {nameof(NumberOfNotices)}: {NumberOfNotices}, {nameof(MeetingNotices)}: {MeetingNotices}, {nameof(GeneralNotices)}: {GeneralNotices}";
        }
    }
    
    /// <summary>
    /// The number of general notices plus the notices them selves
    /// </summary>
    [Serializable]
    public struct GeneralNotices {
        [XmlElement(ElementName = "NumberGeneralRecords")]
        public int NumberOfGeneralNotices;
        
        [XmlElement(ElementName = "General")] public List<GeneralNotice> Notices;

        public override string ToString() {
            return $"{nameof(NumberOfGeneralNotices)}: {NumberOfGeneralNotices}, {nameof(Notices)}: [{string.Join(", ", Notices)}]";
        }
    }
    
    /// <summary>
    /// A general notice
    /// </summary>
    [Serializable]
    public struct GeneralNotice {
        /// <summary>
        /// Index of the general notices in terms of the other general notices
        /// </summary>
        [XmlAttribute(AttributeName = "Index")]
        public int Index;
        
        /// <summary>
        /// The teacher who created the notice
        /// </summary>
        [XmlElement(ElementName = "Teacher")] public string Teacher;
        
        /// <summary>
        /// Notice subject line
        /// </summary>
        [XmlElement(ElementName = "Subject")] public string Subject;
        
        /// <summary>
        /// Notice body
        /// </summary>
        [XmlElement(ElementName = "Body")] public string Body;
    }
    
    /// <summary>
    /// The number of meeting notices plus the notices them selves
    /// </summary>
    [Serializable]
    public struct MeetingNotices {
        [XmlElement(ElementName = "NumberMeetingRecords")]
        public int NumberOfGeneralNotices;

        [XmlElement(ElementName = "Meeting")] public List<MeetingNotice> Notices;

        public override string ToString() {
            return $"{nameof(NumberOfGeneralNotices)}: {NumberOfGeneralNotices}, {nameof(Notices)}: [{string.Join(", ", Notices)}]";
        }
    }
    
    /// <summary>
    /// A meeting notice
    /// </summary>
    [Serializable]
    public struct MeetingNotice {
        /// <summary>
        /// Index of the general notices in terms of the other general notices
        /// </summary>
        [XmlAttribute(AttributeName = "Index")]
        public int Index;
        
        /// <summary>
        /// The teacher who created the notice
        /// </summary>
        [XmlElement(ElementName = "Teacher")] public string Teacher;
        
        /// <summary>
        /// Notice subject line
        /// </summary>
        [XmlElement(ElementName = "Subject")] public string Subject;
        
        /// <summary>
        /// Notice body
        /// </summary>
        [XmlElement(ElementName = "Body")] public string Body;
        
        /// <summary>
        /// The time affect students should meet, will not always be a time stamp, may be "after lunch" etc
        /// </summary>
        [XmlElement(ElementName = "TimeMeet")] public string TimeMeet;
        /// <summary>
        /// The date affected students should meet
        /// </summary>
        [XmlElement(ElementName = "DateMeet")] public string DateMeet;

        /// <summary>
        /// The location affected students should meet
        /// </summary>
        [XmlElement(ElementName = "LocationMeet")]
        public string LocationMeet;

        public override string ToString() {
            return $"{nameof(Index)}: {Index}, {nameof(Teacher)}: {Teacher}, {nameof(Subject)}: {Subject}, {nameof(Body)}: {Body}, {nameof(TimeMeet)}: {TimeMeet}, {nameof(DateMeet)}: {DateMeet}, {nameof(LocationMeet)}: {LocationMeet}";
        }
    }
}