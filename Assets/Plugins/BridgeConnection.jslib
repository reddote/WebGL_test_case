mergeInto(LibraryManager.library, {

  ChangeAnimationText: function (text) {
    document.getElementById("animation").innerHTML = Pointer_stringify(text);
  },

  ChangeLightText: function (text) {
    document.getElementById("light").innerHTML = Pointer_stringify(text);
  },

  ChangeCabinetText: function (text) {
    document.getElementById("cabinet").innerHTML = Pointer_stringify(text);
  },

  ChangeUICountText: function (text) {
    document.getElementById("count").innerHTML = Pointer_stringify(text);
  },

  ChangeUITimerText: function (text) {
    document.getElementById("timer").innerHTML = Pointer_stringify(text);
  },

  ChangePanelText: function (text) {
    document.getElementById("panel").innerHTML = Pointer_stringify(text);
  },


});