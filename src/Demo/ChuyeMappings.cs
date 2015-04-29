using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Demo {
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Password);
            Map(x => x.PasswordSalt);
            Map(x => x.PasswordFormat);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
        }
    }

    public class CommonqaMap : ClassMap<Commonqa>
    {
        public CommonqaMap()
        {
            Id(x => x.Id);
            Map(x => x.Question);
            Map(x => x.Answer);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
        }
    }

    public class FeedbackMap : ClassMap<Feedback>
    {
        public FeedbackMap()
        {
            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.Content);
            Map(x => x.ContactInfo);
            Map(x => x.CreateAt);
            Map(x => x.ReadStatus);
        }
    }

    public class HotworkbannersMap : ClassMap<Hotworkbanners>
    {
        public HotworkbannersMap()
        {
            Id(x => x.Id);
            Map(x => x.Thumbnail);
            Map(x => x.LinkUrl);
            Map(x => x.Sort);
            Map(x => x.WorkId);
        }
    }

    public class LayoutMap : ClassMap<Layout>
    {
        public LayoutMap()
        {
            Id(x => x.Id);
            Map(x => x.GuId);
            Map(x => x.Description);
            Map(x => x.CreateAt);
            Map(x => x.Label);
            Map(x => x.Thumbnail);
            Map(x => x.Medias);
            Map(x => x.UpdateAt);
            Map(x => x.State);
            Map(x => x.Sort);
            Map(x => x.Version);
            Map(x => x.AllowCustom);
        }
    }

    public class LoginMap : ClassMap<Login>
    {
        public LoginMap()
        {
            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.OpenId);
            Map(x => x.Hash);
            Map(x => x.CreateAt);
            Map(x => x.ActiveAt);
            Map(x => x.ValId);
            Map(x => x.Device);
            Map(x => x.System);
            Map(x => x.App);
            Map(x => x.Version);
            Map(x => x.Resolution);
            Map(x => x.UserAgent);
        }
    }

    public class MediaMap : ClassMap<Media>
    {
        public MediaMap()
        {
            Id(x => x.Id);
            Map(x => x.GuId);
            Map(x => x.Category);
            Map(x => x.UserId);
            Map(x => x.Text);
            Map(x => x.Hash);
            Map(x => x.Uri);
            Map(x => x.CreateAt);
            Map(x => x.Type);
            Map(x => x.Attributes);
            Map(x => x.UpdateAt);
            Map(x => x.ActionLink);
            Map(x => x.Medias);
        }
    }

    public class MembersofroleMap : ClassMap<Membersofrole>
    {
        public MembersofroleMap()
        {
            Id(x => x.Id);
            Map(x => x.Role_Id);
            Map(x => x.Account_Id);
        }
    }

    public class MusicMap : ClassMap<Music>
    {
        public MusicMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Url);
            Map(x => x.Category);
            Map(x => x.CreateAt);
            Map(x => x.MusicType);
            Map(x => x.UserId);
            Map(x => x.ValId);
            Map(x => x.Hash);
        }
    }

    public class Music2Map : ClassMap<Music2>
    {
        public Music2Map()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Artist);
            Map(x => x.Album);
            Map(x => x.Lrc);
            Map(x => x.Url);
            Map(x => x.Picture);
            Map(x => x.CreateAt);
        }
    }

    public class MusicproviderMap : ClassMap<Musicprovider>
    {
        public MusicproviderMap()
        {
            Id(x => x.Id);
            Map(x => x.Provider);
            Map(x => x.ThirdId);
            Map(x => x.Entry);
            Map(x => x.Status);
            Map(x => x.CreateAt);
            Map(x => x.MusicId);
        }
    }

    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Id(x => x.Id);
            Map(x => x.GuId);
            Map(x => x.Medias);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
            Map(x => x.WorkId);
            Map(x => x.LayoutId);
            Map(x => x.Thumbnail);
            Map(x => x.CustomEnable);
        }
    }

    public class ResourceMap : ClassMap<Resource>
    {
        public ResourceMap()
        {
            Id(x => x.Id);
            Map(x => x.Key);
            Map(x => x.CreateAt);
            Map(x => x.Url);
        }
    }

    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
        }
    }

    public class RolepermissionMap : ClassMap<Rolepermission>
    {
        public RolepermissionMap()
        {
            Id(x => x.Id);
            Map(x => x.Permission);
            Map(x => x.Role_Id);
        }
    }

    public class SignupinfoMap : ClassMap<Signupinfo>
    {
        public SignupinfoMap()
        {
            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.GuId);
            Map(x => x.MediaId);
            Map(x => x.Template);
            Map(x => x.CreateAt);
        }
    }

    public class SoftupdateMap : ClassMap<Softupdate>
    {
        public SoftupdateMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Url);
            Map(x => x.CreateAt);
            Map(x => x.Version);
        }
    }

    public class SubscribehistoryMap : ClassMap<Subscribehistory>
    {
        public SubscribehistoryMap()
        {
            Id(x => x.Id);
            Map(x => x.SubscriptionId);
            Map(x => x.WorkId);
            Map(x => x.CreateAt);
            Map(x => x.UserId);
        }
    }

    public class SubscriptionMap : ClassMap<Subscription>
    {
        public SubscriptionMap()
        {
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Category);
            Map(x => x.UserId);
            Map(x => x.Count);
            Map(x => x.CreateAt);
            Map(x => x.Validity);
            Map(x => x.ActiveAt);
            Map(x => x.UpdateAt);
        }
    }

    public class SysloggerMap : ClassMap<Syslogger>
    {
        public SysloggerMap()
        {
            Id(x => x.Id);
            Map(x => x.Content);
            Map(x => x.IosVersion);
            Map(x => x.AppVersion);
            Map(x => x.CreateAt);
            Map(x => x.Time);
        }
    }

    public class SysnoticeMap : ClassMap<Sysnotice>
    {
        public SysnoticeMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Thumbnail);
            Map(x => x.Content);
            Map(x => x.Url);
            Map(x => x.Status);
            Map(x => x.Type);
            Map(x => x.CreateAt);
            Map(x => x.GuId);
            Map(x => x.UpdateAt);
        }
    }

    public class SyssettingMap : ClassMap<Syssetting>
    {
        public SyssettingMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Label);
            Map(x => x.Value);
            Map(x => x.SettingType);
            Map(x => x.CreateAt);
        }
    }

    public class TemplateMap : ClassMap<Template>
    {
        public TemplateMap()
        {
            Id(x => x.Id);
            Map(x => x.GuId);
            Map(x => x.Name);
            Map(x => x.CreateAt);
            Map(x => x.Thumbnail);
            Map(x => x.Pages);
        }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Role);
            Map(x => x.CreateAt);
            Map(x => x.Password);
        }
    }

    public class UserauthMap : ClassMap<Userauth>
    {
        public UserauthMap()
        {
            Id(x => x.Id);
            Map(x => x.OpenId);
            Map(x => x.Subscribe);
            Map(x => x.Nickname);
            Map(x => x.Sex);
            Map(x => x.City);
            Map(x => x.Province);
            Map(x => x.Country);
            Map(x => x.Language);
            Map(x => x.HeadImgUrl);
            Map(x => x.SubscribeTime);
            Map(x => x.UnionId);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
        }
    }

    public class UserproviderMap : ClassMap<Userprovider>
    {
        public UserproviderMap()
        {
            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.OpenId);
            Map(x => x.Provider);
            Map(x => x.CreateAt);
        }
    }

    public class UsersettingMap : ClassMap<Usersetting>
    {
        public UsersettingMap()
        {
            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.HeaderImage);
            Map(x => x.Author);
            Map(x => x.Summary);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
            Map(x => x.Url);
        }
    }

    public class WorkMap : ClassMap<Work>
    {
        public WorkMap()
        {
            Id(x => x.Id);
            Map(x => x.GuId);
            Map(x => x.UserId);
            Map(x => x.Pages);
            Map(x => x.Uri);
            Map(x => x.Access);
            Map(x => x.Share);
            Map(x => x.CreateAt);
            Map(x => x.UpdateAt);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Width);
            Map(x => x.Height);
            Map(x => x.Switch);
            Map(x => x.Mode);
            Map(x => x.BackgroundColor);
            Map(x => x.BackgroundMusic);
            Map(x => x.Thumbnail);
            Map(x => x.ValId);
            Map(x => x.TemplateName);
            Map(x => x.TemplateThumbnail);
            Map(x => x.IsTemplate);
            Map(x => x.CopyrightEnable);
            Map(x => x.PraiseEnable);
            Map(x => x.CustomCopyright);
        }
    }

    public class WorkdetailMap : ClassMap<Workdetail>
    {
        public WorkdetailMap()
        {
            Id(x => x.Id);
            Map(x => x.WorkId);
            Map(x => x.OnlySelf);
            Map(x => x.HotRecommended);
            Map(x => x.CreateAt);
            Map(x => x.IsEvent);
            Map(x => x.SysRecommended);
            Map(x => x.Visibility);
        }
    }

    public class WorkeventMap : ClassMap<Workevent>
    {
        public WorkeventMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Summary);
            Map(x => x.EventWorkRule);
            Map(x => x.Status);
            Map(x => x.StartTime);
            Map(x => x.EndTime);
            Map(x => x.Duration);
        }
    }

    public class WorkeventdetailMap : ClassMap<Workeventdetail>
    {
        public WorkeventdetailMap()
        {
            Id(x => x.Id);
            Map(x => x.WorkEventId);
            Map(x => x.WorkId);
            Map(x => x.ValId);
        }
    }

    public class WorkoperationMap : ClassMap<Workoperation>
    {
        public WorkoperationMap()
        {
            Id(x => x.Id);
            Map(x => x.WorkId);
            Map(x => x.LoginId);
            Map(x => x.Operate);
            Map(x => x.CreateAt);
        }
    }

}

