using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo {    
    public class Account
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Name                      { get; set; }
        public virtual String                     Password                  { get; set; }
        public virtual String                     PasswordSalt              { get; set; }
        public virtual String                     PasswordFormat            { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime                   UpdateAt                  { get; set; }
    }

    public class Commonqa
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Question                  { get; set; }
        public virtual String                     Answer                    { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime                   UpdateAt                  { get; set; }
    }

    public class Feedback
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     Content                   { get; set; }
        public virtual String                     ContactInfo               { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Int32                      ReadStatus                { get; set; }
    }

    public class Hotworkbanners
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual String                     LinkUrl                   { get; set; }
        public virtual Int32                      Sort                      { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
    }

    public class Layout
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual String                     Description               { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     Label                     { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual String                     Medias                    { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
        public virtual Int32?                     State                     { get; set; }
        public virtual Int32?                     Sort                      { get; set; }
        public virtual Int32?                     Version                   { get; set; }
        public virtual Int64?                     AllowCustom               { get; set; }
    }

    public class Login
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     OpenId                   { get; set; }
        public virtual String                     Hash                      { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime                   ActiveAt                  { get; set; }
        public virtual Int32                      ValId                    { get; set; }
        public virtual String                     Device                    { get; set; }
        public virtual String                     System                    { get; set; }
        public virtual String                     App                       { get; set; }
        public virtual String                     Version                   { get; set; }
        public virtual String                     Resolution                { get; set; }
        public virtual String                     UserAgent                 { get; set; }
    }

    public class Media
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual Int32                      Category                  { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     Text                      { get; set; }
        public virtual String                     Hash                      { get; set; }
        public virtual String                     Uri                       { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Int32                      Type                      { get; set; }
        public virtual String                     Attributes                { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
        public virtual String                     ActionLink                { get; set; }
        public virtual String                     Medias                    { get; set; }
    }

    public class Membersofrole
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      Role_Id                  { get; set; }
        public virtual Int32                      Account_Id               { get; set; }
    }

    public class Music
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Name                      { get; set; }
        public virtual String                     Url                       { get; set; }
        public virtual String                     Category                  { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Int32?                     MusicType                 { get; set; }
        public virtual Int32?                     UserId                   { get; set; }
        public virtual Int64?                     ValId                    { get; set; }
        public virtual String                     Hash                      { get; set; }
    }

    public class Music2
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Artist                    { get; set; }
        public virtual String                     Album                     { get; set; }
        public virtual String                     Lrc                       { get; set; }
        public virtual String                     Url                       { get; set; }
        public virtual String                     Picture                   { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
    }

    public class Musicprovider
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Provider                  { get; set; }
        public virtual String                     ThirdId                  { get; set; }
        public virtual String                     Entry                     { get; set; }
        public virtual Int32                      Status                    { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Int32                      MusicId                  { get; set; }
    }

    public class Page
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual String                     Medias                    { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
        public virtual Int32                      LayoutId                 { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual Int64?                     CustomEnable              { get; set; }
    }

    public class Resource
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Key                       { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     Url                       { get; set; }
    }

    public class Role
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Name                      { get; set; }
        public virtual String                     Description               { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime                   UpdateAt                  { get; set; }
    }

    public class Rolepermission
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Permission                { get; set; }
        public virtual Int32                      Role_Id                  { get; set; }
    }

    public class Signupinfo
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual Int32                      MediaId                  { get; set; }
        public virtual String                     Template                  { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
    }

    public class Softupdate
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Description               { get; set; }
        public virtual String                     Url                       { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     Version                   { get; set; }
    }

    public class Subscribehistory
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      SubscriptionId           { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     UserId                   { get; set; }
    }

    public class Subscription
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Code                      { get; set; }
        public virtual Int32                      Category                  { get; set; }
        public virtual Int32?                     UserId                   { get; set; }
        public virtual Int32?                     Count                     { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Single?                    Validity                  { get; set; }
        public virtual DateTime?                  ActiveAt                  { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
    }

    public class Syslogger
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Content                   { get; set; }
        public virtual String                     IosVersion                { get; set; }
        public virtual String                     AppVersion                { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime?                  Time                      { get; set; }
    }

    public class Sysnotice
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual String                     Content                   { get; set; }
        public virtual String                     Url                       { get; set; }
        public virtual Int64                      Status                    { get; set; }
        public virtual Int32                      Type                      { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
    }

    public class Syssetting
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Label                     { get; set; }
        public virtual String                     Value                     { get; set; }
        public virtual Int32                      SettingType               { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
    }

    public class Template
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual String                     Name                      { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual String                     Pages                     { get; set; }
    }

    public class User
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Name                      { get; set; }
        public virtual String                     Role                      { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual String                     Password                  { get; set; }
    }

    public class Userauth
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     OpenId                   { get; set; }
        public virtual Int32?                     Subscribe                 { get; set; }
        public virtual String                     Nickname                  { get; set; }
        public virtual String                     Sex                       { get; set; }
        public virtual String                     City                      { get; set; }
        public virtual String                     Province                  { get; set; }
        public virtual String                     Country                   { get; set; }
        public virtual String                     Language                  { get; set; }
        public virtual String                     HeadImgUrl                { get; set; }
        public virtual DateTime?                  SubscribeTime             { get; set; }
        public virtual String                     UnionId                  { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
    }

    public class Userprovider
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     OpenId                   { get; set; }
        public virtual String                     Provider                  { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
    }

    public class Usersetting
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     HeaderImage               { get; set; }
        public virtual String                     Author                    { get; set; }
        public virtual String                     Summary                   { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime                   UpdateAt                  { get; set; }
        public virtual String                     Url                       { get; set; }
    }

    public class Work
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     GuId                     { get; set; }
        public virtual Int32                      UserId                   { get; set; }
        public virtual String                     Pages                     { get; set; }
        public virtual String                     Uri                       { get; set; }
        public virtual Int32                      Access                    { get; set; }
        public virtual Int32                      Share                     { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual DateTime?                  UpdateAt                  { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Description               { get; set; }
        public virtual String                     Width                     { get; set; }
        public virtual String                     Height                    { get; set; }
        public virtual String                     Switch                    { get; set; }
        public virtual String                     Mode                      { get; set; }
        public virtual String                     BackgroundColor           { get; set; }
        public virtual String                     BackgroundMusic           { get; set; }
        public virtual String                     Thumbnail                 { get; set; }
        public virtual Int32                      ValId                    { get; set; }
        public virtual String                     TemplateName              { get; set; }
        public virtual String                     TemplateThumbnail         { get; set; }
        public virtual Int64                      IsTemplate                { get; set; }
        public virtual Int64                      CopyrightEnable           { get; set; }
        public virtual Int64                      PraiseEnable              { get; set; }
        public virtual Int64                      CustomCopyright           { get; set; }
    }

    public class Workdetail
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
        public virtual Int32                      OnlySelf                  { get; set; }
        public virtual Int32                      HotRecommended            { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
        public virtual Int64                      IsEvent                   { get; set; }
        public virtual Int64                      SysRecommended            { get; set; }
        public virtual Int64?                     Visibility                { get; set; }
    }

    public class Workevent
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual String                     Title                     { get; set; }
        public virtual String                     Summary                   { get; set; }
        public virtual String                     EventWorkRule             { get; set; }
        public virtual Int32                      Status                    { get; set; }
        public virtual DateTime                   StartTime                 { get; set; }
        public virtual DateTime                   EndTime                   { get; set; }
        public virtual DateTime                   Duration                  { get; set; }
    }

    public class Workeventdetail
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      WorkEventId              { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
        public virtual Int64                      ValId                    { get; set; }
    }

    public class Workoperation
    {
        public virtual Int32                      Id                       { get; set; }
        public virtual Int32                      WorkId                   { get; set; }
        public virtual Int32                      LoginId                  { get; set; }
        public virtual Int32                      Operate                   { get; set; }
        public virtual DateTime                   CreateAt                  { get; set; }
    }

}

