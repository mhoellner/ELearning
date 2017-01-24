//<![CDATA[
(function () {
  M.util.load_flowplayer();
  setTimeout("fix_column_widths()", 20);
  window.Y.use("moodle-core-dock-loader",
      function () {
        M.core.dock.loader.initLoader();
      });
  window.Y.use("moodle-block_navigation-navigation",
      function () {
        M.block_navigation.init_add_tree({
          "id": "112421",
          "instance": "112421",
          "candock": true,
          "courselimit": "20",
          "expansionlimit": 0
        });
      });
  window.Y.use("moodle-block_navigation-navigation",
      function () {
        M.block_navigation.init_add_tree({ "id": "112422", "instance": "112422", "candock": true });
      });
  window.Y.use("moodle-filter_mathjaxloader-loader",
      function () {
        M.filter_mathjaxloader.configure({
          "mathjaxconfig":
              "\nMathJax.Hub.Config({\n    config: [\"Accessible.js\", \"Safe.js\"],\n    errorSettings: { message: [\"!\"] },\n    skipStartupTypeset: true,\n    messageStyle: \"none\"\n});\n",
          "lang": "de"
        });
      });
  window.Y.use("moodle-filter_glossary-autolinker",
      function () {
        M.filter_glossary.init_filter_autolinking({ "courseid": 0 });
      });
  M.util.help_popups.setup(window.Y);
  window.Y.use("moodle-core-popuphelp",
      function () {
        M.core.init_popuphelp();
      });
  M.util.init_skiplink(window.Y);
  window.Y.use("moodle-core-formautosubmit",
      function () {
        M.core.init_formautosubmit({ "selectid": "single_select57ea5a5e55ec44", "nothing": false });
      });
  M.util.init_block_hider(window.Y,
  {
    "id": "inst112421",
    "title": "Navigation",
    "preference": "block112421hidden",
    "tooltipVisible": "Block Navigation verbergen",
    "tooltipHidden": "Block Navigation anzeigen"
  });
  M.util.init_block_hider(window.Y,
  {
    "id": "inst3388",
    "title": "Moodle Helpline",
    "preference": "block3388hidden",
    "tooltipVisible": "Block Moodle Helpline verbergen",
    "tooltipHidden": "Block Moodle Helpline anzeigen"
  });
  M.util.init_block_hider(window.Y,
  {
    "id": "inst182873",
    "title": "IT News",
    "preference": "block182873hidden",
    "tooltipVisible": "Block IT News verbergen",
    "tooltipHidden": "Block IT News anzeigen"
  });
  M.util.init_block_hider(window.Y,
  {
    "id": "inst705",
    "title": "Informationen",
    "preference": "block705hidden",
    "tooltipVisible": "Block Informationen verbergen",
    "tooltipHidden": "Block Informationen anzeigen"
  });
  M.util.init_block_hider(window.Y,
  {
    "id": "inst248080",
    "title": "Hauptmen\u00fc",
    "preference": "block248080hidden",
    "tooltipVisible": "Block Hauptmen\u00fc verbergen",
    "tooltipHidden": "Block Hauptmen\u00fc anzeigen"
  });
  window.Y.use("moodle-course-categoryexpander",
      function () {
        window.Y.Moodle.course.categoryexpander.init();
      });
  M.util.js_pending('random57ea5a5e55ec410');
  window.Y.on('domready',
      function () {
        M.util.js_complete("init");
        M.util.js_complete('random57ea5a5e55ec410');
      });
})();
//]]>