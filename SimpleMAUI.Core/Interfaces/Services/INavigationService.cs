using SimpleMAUI.Core.Interfaces.ViewModels;

namespace SimpleMAUI.Core.Interfaces.Services;

public enum PageType
{
    HomePage,
    MyPostPage,
    ChatPage,
    InviteFriendsPage,
    NotificationPage,
    AboutUsPage,
    SupportPage,
    FaqPage
}

public interface INavigationService
{
    void GoTo(PageType pageType, IParameters? parameters = null);
    void GoBack();
}
