$path = "C:/Users/Ian Robertson/Pictures/game/Dungeon/Assets/Sprites/Player/Idle_Left" #target directory

[System.Reflection.Assembly]::LoadWithPartialName("System.Drawing")
Get-ChildItem -recurse ($path) -include @("*.png", "*.jpg") |
ForEach-Object {
  $image = [System.Drawing.image]::FromFile( $_ )
  $image.rotateflip("RotateNoneFlipX")
  $image.save($_)
}