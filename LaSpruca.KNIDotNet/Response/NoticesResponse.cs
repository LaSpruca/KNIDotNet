using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LaSpruca.KNIDotNet.Response {
    [Serializable, XmlRoot(Namespace = "", ElementName = "NoticesResults")]
    public struct NoticesResponse {
        [XmlAttribute(AttributeName = "apiversion")]
        public string ApiVersion;

        [XmlAttribute(AttributeName = "portalversion")]
        public string PortalVersion;

        [XmlElement(ElementName = "AccessLevel")]
        public string AccessLevel;

        [XmlElement(ElementName = "NoticesDate")]
        public string NoticesDate;

        [XmlElement(ElementName = "NumberRecords")]
        public int NumberOfNotices;

        [XmlElement(ElementName = "MeetingNotices")]
        public MeetingNotices MeetingNotices;

        [XmlElement(ElementName = "GeneralNotices")]
        public GeneralNotices GeneralNotices;
    }
    [Serializable]
    public struct GeneralNotices {
        [XmlElement(ElementName = "NumberGeneralRecords")]
        public int NumberOfGeneralNotices;
        
        [XmlElement(ElementName = "General")] public List<GeneralNotice> Notices;
    }
    
    [Serializable]
    public struct GeneralNotice {
        [XmlAttribute(AttributeName = "Index")]
        public int Index;
        [XmlElement(ElementName = "Teacher")] public string Teacher;
        [XmlElement(ElementName = "Subject")] public string Subject;
        [XmlElement(ElementName = "Body")] public string Body;
    }

    [Serializable]
    public struct MeetingNotices {
        [XmlElement(ElementName = "NumberMeetingRecords")]
        public int NumberOfGeneralNotices;

        [XmlElement(ElementName = "Meeting")] public List<MeetingNotice> Notices;
    }

    [Serializable]
    public struct MeetingNotice {
        [XmlAttribute(AttributeName = "Index")]
        public int Index;
        [XmlElement(ElementName = "Teacher")] public string Teacher;
        [XmlElement(ElementName = "Subject")] public string Subject;
        [XmlElement(ElementName = "Body")] public string Body;
        [XmlElement(ElementName = "TimeMeet")] public string TimeMeet;
        [XmlElement(ElementName = "DateMeet")] public string DateMeet;

        [XmlElement(ElementName = "LocationMeet")]
        public string LocationMeet;
    }
}