# Lyric Finder by Zach Rosin and Samuel McKinney

This application allows the user to:
	- Search for songs in a music API
	- View the Results of a the search by Title and artist
	- Select a song and see an expanded version of the Lyrics
	- Press a button that allows them to save that song as a favorite
	- Favorite songs are saved permanently, even after closing the application.
	- Favorite songs get added to a list on the main page
		- And can be pressed at any time to reveal the Lyrics

 Classes:
	Model:
		ApiCalls.cs
		FavoriteSongsContext.cs
		Song.cs
	ViewModel:
		FavoriteSongsViewModel.cs
		MusicViewModel.cs
		SongViewModel.cs
	View
		MainPage.xaml.cs
		LyricPage.xaml.cs
		AboutPage.xaml.cs

Zach Rosin contributed in:
	- About Page
	- Lyric Page
		*Api request and display of lyrics
	- Entity FrameWork and Favorites display
	- Helped with Main page Search display

Samuel McKinney
	- Main page Search display
	- Search Api Request
	- Main Page search Text Box, Combo Box and Search listView.
	- Xaml organization and resize of main page
	- Xaml organization of favorite button

Work was 50/50.

