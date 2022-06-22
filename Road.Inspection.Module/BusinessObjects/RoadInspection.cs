﻿using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Road.Inspection.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Авто замын үзлэг")]
    public class RoadInspection : BaseObject
    {
        public RoadInspection(Session session) : base(session) { }

        private string _teamLeader;
        [XafDisplayName("Багийн ахлагч")]
        public string teamLeader { get { return _teamLeader; } set { SetPropertyValue(nameof(teamLeader), ref _teamLeader, value); } }

        private string _inspectionEngineer;
        [VisibleInListView(false)]
        [XafDisplayName("Үзлэгийн инженер")]
        public string inspectionEngineer { get { return _inspectionEngineer; } set { SetPropertyValue(nameof(inspectionEngineer), ref _inspectionEngineer, value); } }

        private string _measuringInstrument;
        [XafDisplayName("Хэмжилтийн хэрэгсэл")]
        public string measuringInstrument { get { return _measuringInstrument; } set { SetPropertyValue(nameof(measuringInstrument), ref _measuringInstrument, value); } }

        private string _other;
        [VisibleInListView(false)]
        [XafDisplayName("Бусад")]
        public string other { get { return _other; } set { SetPropertyValue(nameof(other), ref _other, value); } }

        private string _markType;
        [VisibleInListView(false), Size(20)]
        [XafDisplayName("Марк, төрөл")]
        public string markType { get { return _markType; } set { SetPropertyValue(nameof(markType), ref _markType, value); } }

        private string _plateNumber;
        [VisibleInListView(false), Size(20)]
        [XafDisplayName("Улсын дугаар")]
        public string plateNumber { get { return _plateNumber; } set { SetPropertyValue(nameof(plateNumber), ref _plateNumber, value); } }

        private string _roadNumber;
        [VisibleInListView(false), Size(6)]
        [XafDisplayName("Замын дугаар")]
        public string roadNumber { get { return _roadNumber; } set { SetPropertyValue(nameof(roadNumber), ref _roadNumber, value); } }

        private string _roadDirection;
        [VisibleInListView(false), Size(30)]
        [XafDisplayName("Замын чиглэл")]
        public string roadDirection { get { return _roadDirection; } set { SetPropertyValue(nameof(roadDirection), ref _roadDirection, value); } }

        private string _category;
        [VisibleInListView(false), Size(30)]
        [XafDisplayName("Ангилал /зэрэг/")]
        public string category { get { return _category; } set { SetPropertyValue(nameof(category), ref _category, value); } }

        private string _startPoint;
        [VisibleInListView(false), XafDisplayName("Эхлэл цэг"), Size(30)]
        public string startPoint { get { return _startPoint; } set { SetPropertyValue(nameof(startPoint), ref _startPoint, value); } }

        private string _endPoint;
        [VisibleInListView(false), XafDisplayName("Төгсгөлийн цэг"), Size(30)]
        public string endPoint { get { return _endPoint; } set { SetPropertyValue(nameof(endPoint), ref _endPoint, value); } }

        //private string _isDelivery;
        //[ModelDefault("AllowEdit", "false"), VisibleInListView(false)]
        //public string isDelivery { get { return _isDelivery; } set { SetPropertyValue(nameof(isDelivery), ref _isDelivery, value); } }

        private string _kilometr;
        [VisibleInListView(false), XafDisplayName("Км-ээс"), Size(20)]
        public string kilometr { get { return _kilometr; } set { SetPropertyValue(nameof(kilometr), ref _kilometr, value); } }

        private string _kilometrs;
        [XafDisplayName("Км хүртэл"), Size(20)]
        public string kilometrs { get { return _kilometrs; } set { SetPropertyValue(nameof(kilometrs), ref _kilometrs, value); } }

        private string _endCoordinates;
        [XafDisplayName("Төгсгөлийн цэгийн солбилцол"), Size(30)]
        public string endCoordinates { get { return _endCoordinates; } set { SetPropertyValue(nameof(endCoordinates), ref _endCoordinates, value); } }

        private WeatherConditions _weather;
        [XafDisplayName("Цаг агаарын байдал")]
        public WeatherConditions weather { get { return _weather; } set { SetPropertyValue(nameof(weather), ref _weather, value); } }

        private string _degrees;
        [VisibleInListView(false), XafDisplayName("Өдрийн хэм"), Size(4)]
        public string degrees { get { return _degrees; } set { SetPropertyValue(nameof(degrees), ref _degrees, value); } }

        //private string _beforeInspection;
        //[VisibleInListView(false), XafDisplayName("Км хүртэл"),]
        //public string beforeInspection { get { return _beforeInspection; } set { SetPropertyValue(nameof(beforeInspection), ref _beforeInspection, value); } }

        //private string _currentInspection;
        //[VisibleInListView(false)]
        //public string currentInspection { get { return _currentInspection; } set { SetPropertyValue(nameof(currentInspection), ref _currentInspection, value); } }

        private string _beforeLeftLane;
        [VisibleInListView(false), XafDisplayName("Өмнөх өдрийн зүүн зорчих хэсэг"), Size(5)]
        public string beforeLeftLane { get { return _beforeLeftLane; } set { SetPropertyValue(nameof(beforeLeftLane), ref _beforeLeftLane, value); } }

        private string _beforeRightLane;
        [VisibleInListView(false), XafDisplayName("Өмнөх өдрийн баруун зорчих хэсэг"), Size(5)]
        public string beforeRightLane { get { return _beforeRightLane; } set { SetPropertyValue(nameof(beforeRightLane), ref _beforeRightLane, value); } }

        private string _currentLeftLane;
        [VisibleInListView(false), XafDisplayName("Одоогийн зүүн зорчих хэсэг"), Size(5)]
        public string currentLeftLane { get { return _currentLeftLane; } set { SetPropertyValue(nameof(currentLeftLane), ref _currentLeftLane, value); } }

        private string _currentRightLane;
        [VisibleInListView(false), XafDisplayName("Одоогийн баруун зорчих хэсэг"), Size(5)]
        public string currentRightLane { get { return _currentRightLane; } set { SetPropertyValue(nameof(currentRightLane), ref _currentRightLane, value); } }

        private string _specialNote;
        [XafDisplayName("Онцгой тэмдэглэл"), Size(200)]
        public string specialNote { get { return _specialNote; } set { SetPropertyValue(nameof(specialNote), ref _specialNote, value); } }

        private string _subscriberName;
        [VisibleInListView(false), XafDisplayName("Захиалагчийн нэр"), Size(25)]
        public string subscriberName { get { return _subscriberName; } set { SetPropertyValue(nameof(subscriberName), ref _subscriberName, value); } }

        private string _subscriberPositions;
        [VisibleInListView(false), XafDisplayName("Захиалагчийн албан тушаал"), Size(8)]
        public string subscriberPositions { get { return _subscriberPositions; } set { SetPropertyValue(nameof(subscriberPositions), ref _subscriberPositions, value); } }

        private string _consultantName;
        [VisibleInListView(false), XafDisplayName("Зөвлөхийн нэр"), Size(25)]
        public string consultantName { get { return _consultantName; } set { SetPropertyValue(nameof(consultantName), ref _consultantName, value); } }

        private string _consultantPositions;
        [VisibleInListView(false), XafDisplayName("Зөвлөхийн албан тушаал"), Size(8)]
        public string consultantPositions { get { return _consultantPositions; } set { SetPropertyValue(nameof(consultantPositions), ref _consultantPositions, value); } }

        private string _roadManager;
        [VisibleInListView(false), XafDisplayName("Зам хариуцагчийн нэр"), Size(25)]
        public string roadManager { get { return _roadManager; } set { SetPropertyValue(nameof(roadManager), ref _roadManager, value); } }

        private string _roadPositions;
        [VisibleInListView(false), XafDisplayName("Зам хариуцагчийн албан тушаал"), Size(8)]
        public string roadPositions { get { return _roadPositions; } set { SetPropertyValue(nameof(roadPositions), ref _roadPositions, value); } }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Замын эвдрэл гэмтэл")]
        public XPCollection<RoadItem> roadItems { get { return GetCollection<RoadItem>(nameof(roadItems)); } }

    }
}