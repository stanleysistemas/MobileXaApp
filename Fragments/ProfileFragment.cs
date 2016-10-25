using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Activities;
using Fragment = Android.Support.V4.App.Fragment;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using UniversalImageLoader.Core;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using NavDrawer.Core.ViewModels;
using Android.Runtime;

namespace NavDrawer.Fragments
{
	[MvxFragment(typeof(HomeViewModel), Resource.Id.content_frame)]
	[Register("navdrawer.fragments.ProfileFragment")]
	public class ProfileFragment : MvxFragment<ProfileViewModel>
	{
		private ImageLoader imageLoader;
		public ProfileFragment()
		{
			this.RetainInstance = true;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.fragment_profile, null);
			imageLoader = ImageLoader.Instance;
			view.FindViewById<TextView>(Resource.Id.profile_name).Text = "";
			view.FindViewById<TextView>(Resource.Id.profile_description).Text = "";
			//Colocar aqui a foto do perfil
			imageLoader.DisplayImage("", view.FindViewById<ImageView>(Resource.Id.profile_image));

			view.FindViewById<ImageView>(Resource.Id.profile_image).Click += (sender, args) =>
				{
					var builder = new NotificationCompat.Builder(Activity)
					.SetSmallIcon(Resource.Drawable.ic_launcher)
					.SetContentTitle("Clique aqui para ver detalhes dos Amigos")
					.SetContentText("Novo Amigo!!");
							
					var friendActivity = new Intent(Activity, typeof(FriendActivity));

					PendingIntent pendingIntent = PendingIntent.GetActivity(Activity, 0, friendActivity, 0);
				  

					builder.SetContentIntent(pendingIntent);
					builder.SetAutoCancel(true);
					var notificationManager = 
						(NotificationManager) Activity.GetSystemService(Context.NotificationService);
					notificationManager.Notify(0, builder.Build());
				};
			return view;
		}

		/*var pendingIntent = Android.App.TaskStackBuilder.Create(Activity)
									 .AddNextIntentWithParentStack(friendActivity)
									 .GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);*/
	}
}