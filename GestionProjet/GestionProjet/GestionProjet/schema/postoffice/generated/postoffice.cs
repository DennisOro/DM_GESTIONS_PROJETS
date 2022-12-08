﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8835
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.canadapost.ca/ws/postoffice", IsNullable=false)]
public partial class links {
    
    private LinkType[] linkField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("link")]
    public LinkType[] link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.canadapost.ca/ws/postoffice")]
[System.Xml.Serialization.XmlRootAttribute("link", Namespace="http://www.canadapost.ca/ws/postoffice", IsNullable=false)]
public partial class LinkType {
    
    private string hrefField;
    
    private string relField;
    
    private string indexField;
    
    private string mediatypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rel {
        get {
            return this.relField;
        }
        set {
            this.relField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
    public string index {
        get {
            return this.indexField;
        }
        set {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("media-type", DataType="normalizedString")]
    public string mediatype {
        get {
            return this.mediatypeField;
        }
        set {
            this.mediatypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.canadapost.ca/ws/postoffice")]
public partial class PostOfficeAddressType {
    
    private string cityField;
    
    private decimal latitudeField;
    
    private decimal longitudeField;
    
    private string postalcodeField;
    
    private string provinceField;
    
    private string officeaddressField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string city {
        get {
            return this.cityField;
        }
        set {
            this.cityField = value;
        }
    }
    
    /// <remarks/>
    public decimal latitude {
        get {
            return this.latitudeField;
        }
        set {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    public decimal longitude {
        get {
            return this.longitudeField;
        }
        set {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("postal-code")]
    public string postalcode {
        get {
            return this.postalcodeField;
        }
        set {
            this.postalcodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string province {
        get {
            return this.provinceField;
        }
        set {
            this.provinceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("office-address", DataType="normalizedString")]
    public string officeaddress {
        get {
            return this.officeaddressField;
        }
        set {
            this.officeaddressField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
[System.Xml.Serialization.XmlRootAttribute("post-office-list", Namespace="http://www.canadapost.ca/ws/postoffice", IsNullable=false)]
public partial class postofficelist {
    
    private postofficelistPostoffice[] postofficeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("post-office")]
    public postofficelistPostoffice[] postoffice {
        get {
            return this.postofficeField;
        }
        set {
            this.postofficeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
public partial class postofficelistPostoffice {
    
    private PostOfficeAddressType addressField;
    
    private decimal distanceField;
    
    private string locationField;
    
    private string nameField;
    
    private string officeidField;
    
    private bool bilingualdesignationField;
    
    private LinkType linkField;
    
    /// <remarks/>
    public PostOfficeAddressType address {
        get {
            return this.addressField;
        }
        set {
            this.addressField = value;
        }
    }
    
    /// <remarks/>
    public decimal distance {
        get {
            return this.distanceField;
        }
        set {
            this.distanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("office-id", DataType="normalizedString")]
    public string officeid {
        get {
            return this.officeidField;
        }
        set {
            this.officeidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bilingual-designation")]
    public bool bilingualdesignation {
        get {
            return this.bilingualdesignationField;
        }
        set {
            this.bilingualdesignationField = value;
        }
    }
    
    /// <remarks/>
    public LinkType link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
[System.Xml.Serialization.XmlRootAttribute("post-office-detail", Namespace="http://www.canadapost.ca/ws/postoffice", IsNullable=false)]
public partial class postofficedetail {
    
    private PostOfficeAddressType addressField;
    
    private string locationField;
    
    private string nameField;
    
    private string officeidField;
    
    private bool bilingualdesignationField;
    
    private postofficedetailHourslist[] hourslistField;
    
    /// <remarks/>
    public PostOfficeAddressType address {
        get {
            return this.addressField;
        }
        set {
            this.addressField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString")]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("office-id", DataType="normalizedString")]
    public string officeid {
        get {
            return this.officeidField;
        }
        set {
            this.officeidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bilingual-designation")]
    public bool bilingualdesignation {
        get {
            return this.bilingualdesignationField;
        }
        set {
            this.bilingualdesignationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("hours-list")]
    public postofficedetailHourslist[] hourslist {
        get {
            return this.hourslistField;
        }
        set {
            this.hourslistField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
public partial class postofficedetailHourslist {
    
    private postofficedetailHourslistDay dayField;
    
    private string[] timeField;
    
    /// <remarks/>
    public postofficedetailHourslistDay day {
        get {
            return this.dayField;
        }
        set {
            this.dayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("time", DataType="normalizedString")]
    public string[] time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/postoffice")]
public enum postofficedetailHourslistDay {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("6")]
    Item6,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("7")]
    Item7,
}