//<![CDATA[
var M = {};
M.yui = {};
M.pageloadstarttime = new Date();
M.cfg = {
  "wwwroot": "http:\/\/moodle.hwr-berlin.de",
  "sesskey": "rEMv9dHZ4w",
  "loadingicon":
      "http:\/\/moodle.hwr-berlin.de\/theme\/image.php\/lambda\/core\/1472726786\/i\/loading_small",
  "themerev": "1472726786",
  "slasharguments": 1,
  "theme": "lambda",
  "jsrev": "1472726786",
  "admin": "admin",
  "svgicons": true
};
var yui1ConfigFn = function (me) {
  if (/-skin|reset|fonts|grids|base/.test(me.name)) {
    me.type = 'css';
    me.path = me.path.replace(/\.js/, '.css');
    me.path = me.path.replace(/\/yui2-skin/, '/assets/skins/sam/yui2-skin')
  }
};
var yui2ConfigFn = function (me) {
  var parts = me.name.replace(/^moodle-/, '').split('-'),
      component = parts.shift(),
      module = parts[0],
      min = '-min';
  if (/-(skin|core)$/.test(me.name)) {
    parts.pop();
    me.type = 'css';
    min = ''
  };
  if (module) {
    var filename = parts.join('-');
    me.path = component + '/' + module + '/' + filename + min + '.' + me.type
  } else me.path = component + '/' + component + '.' + me.type
};
YUI_config = {
  "debug": false,
  "base": "http:\/\/moodle.hwr-berlin.de\/lib\/yuilib\/3.17.2\/",
  "comboBase": "http:\/\/moodle.hwr-berlin.de\/theme\/yui_combo.php?",
  "combine": true,
  "filter": null,
  "insertBefore": "firstthemesheet",
  "groups": {
    "yui2": {
      "base": "http:\/\/moodle.hwr-berlin.de\/lib\/yuilib\/2in3\/2.9.0\/build\/",
      "comboBase": "http:\/\/moodle.hwr-berlin.de\/theme\/yui_combo.php?",
      "combine": true,
      "ext": false,
      "root": "2in3\/2.9.0\/build\/",
      "patterns": { "yui2-": { "group": "yui2", "configFn": yui1ConfigFn } }
    },
    "moodle": {
      "name": "moodle",
      "base": "http:\/\/moodle.hwr-berlin.de\/theme\/yui_combo.php?m\/1472726786\/",
      "combine": true,
      "comboBase": "http:\/\/moodle.hwr-berlin.de\/theme\/yui_combo.php?",
      "ext": false,
      "root": "m\/1472726786\/",
      "patterns": { "moodle-": { "group": "moodle", "configFn": yui2ConfigFn } },
      "filter": null,
      "modules": {
        "moodle-core-actionmenu": { "requires": ["base", "event", "node-event-simulate"] },
        "moodle-core-notification": { "requires": ["moodle-core-notification-dialogue", "moodle-core-notification-alert", "moodle-core-notification-confirm", "moodle-core-notification-exception", "moodle-core-notification-ajaxexception"] },
        "moodle-core-notification-dialogue": { "requires": ["base", "node", "panel", "escape", "event-key", "dd-plugin", "moodle-core-widget-focusafterclose", "moodle-core-lockscroll"] },
        "moodle-core-notification-alert": { "requires": ["moodle-core-notification-dialogue"] },
        "moodle-core-notification-confirm": { "requires": ["moodle-core-notification-dialogue"] },
        "moodle-core-notification-exception": { "requires": ["moodle-core-notification-dialogue"] },
        "moodle-core-notification-ajaxexception": { "requires": ["moodle-core-notification-dialogue"] },
        "moodle-core-tooltip": { "requires": ["base", "node", "io-base", "moodle-core-notification-dialogue", "json-parse", "widget-position", "widget-position-align", "event-outside", "cache-base"] },
        "moodle-core-blocks": { "requires": ["base", "node", "io", "dom", "dd", "dd-scroll", "moodle-core-dragdrop", "moodle-core-notification"] },
        "moodle-core-formchangechecker": { "requires": ["base", "event-focus"] },
        "moodle-core-event": { "requires": ["event-custom"] },
        "moodle-core-popuphelp": { "requires": ["moodle-core-tooltip"] },
        "moodle-core-chooserdialogue": { "requires": ["base", "panel", "moodle-core-notification"] },
        "moodle-core-maintenancemodetimer": { "requires": ["base", "node"] },
        "moodle-core-formautosubmit": { "requires": ["base", "event-key"] },
        "moodle-core-lockscroll": { "requires": ["plugin", "base-build"] },
        "moodle-core-dragdrop": { "requires": ["base", "node", "io", "dom", "dd", "event-key", "event-focus", "moodle-core-notification"] },
        "moodle-core-dock": { "requires": ["base", "node", "event-custom", "event-mouseenter", "event-resize", "escape", "moodle-core-dock-loader"] },
        "moodle-core-dock-loader": { "requires": ["escape"] },
        "moodle-core-languninstallconfirm": { "requires": ["base", "node", "moodle-core-notification-confirm", "moodle-core-notification-alert"] },
        "moodle-core-handlebars": { "condition": { "trigger": "handlebars", "when": "after" } },
        "moodle-core-checknet": { "requires": ["base-base", "moodle-core-notification-alert", "io-base"] },
        "moodle-core_availability-form": { "requires": ["base", "node", "event", "panel", "moodle-core-notification-dialogue", "json"] },
        "moodle-backup-backupselectall": { "requires": ["node", "event", "node-event-simulate", "anim"] },
        "moodle-backup-confirmcancel": { "requires": ["node", "node-event-simulate", "moodle-core-notification-confirm"] },
        "moodle-calendar-info": { "requires": ["base", "node", "event-mouseenter", "event-key", "overlay", "moodle-calendar-info-skin"] },
        "moodle-course-toolboxes": { "requires": ["node", "base", "event-key", "node", "io", "moodle-course-coursebase", "moodle-course-util"] },
        "moodle-course-categoryexpander": { "requires": ["node", "event-key"] },
        "moodle-course-modchooser": { "requires": ["moodle-core-chooserdialogue", "moodle-course-coursebase"] },
        "moodle-course-formatchooser": { "requires": ["base", "node", "node-event-simulate"] },
        "moodle-course-dragdrop": { "requires": ["base", "node", "io", "dom", "dd", "dd-scroll", "moodle-core-dragdrop", "moodle-core-notification", "moodle-course-coursebase", "moodle-course-util"] },
        "moodle-course-util": { "requires": ["node"], "use": ["moodle-course-util-base"], "submodules": { "moodle-course-util-base": {}, "moodle-course-util-section": { "requires": ["node", "moodle-course-util-base"] }, "moodle-course-util-cm": { "requires": ["node", "moodle-course-util-base"] } } },
        "moodle-course-management": { "requires": ["base", "node", "io-base", "moodle-core-notification-exception", "json-parse", "dd-constrain", "dd-proxy", "dd-drop", "dd-delegate", "node-event-delegate"] },
        "moodle-form-shortforms": { "requires": ["node", "base", "selector-css3", "moodle-core-event"] },
        "moodle-form-dateselector": { "requires": ["base", "node", "overlay", "calendar"] },
        "moodle-form-passwordunmask": { "requires": ["node", "base"] },
        "moodle-form-showadvanced": { "requires": ["node", "base", "selector-css3"] },
        "moodle-core_message-messenger": { "requires": ["escape", "handlebars", "io-base", "moodle-core-notification-ajaxexception", "moodle-core-notification-alert", "moodle-core-notification-dialogue", "moodle-core-notification-exception"] },
        "moodle-core_message-deletemessage": { "requires": ["node", "event"] },
        "moodle-question-qbankmanager": { "requires": ["node", "selector-css3"] },
        "moodle-question-preview": { "requires": ["base", "dom", "event-delegate", "event-key", "core_question_engine"] },
        "moodle-question-searchform": { "requires": ["base", "node"] },
        "moodle-question-chooser": { "requires": ["moodle-core-chooserdialogue"] },
        "moodle-availability_completion-form": { "requires": ["base", "node", "event", "moodle-core_availability-form"] },
        "moodle-availability_date-form": { "requires": ["base", "node", "event", "io", "moodle-core_availability-form"] },
        "moodle-availability_grade-form": { "requires": ["base", "node", "event", "moodle-core_availability-form"] },
        "moodle-availability_group-form": { "requires": ["base", "node", "event", "moodle-core_availability-form"] },
        "moodle-availability_grouping-form": { "requires": ["base", "node", "event", "moodle-core_availability-form"] },
        "moodle-availability_profile-form": { "requires": ["base", "node", "event", "moodle-core_availability-form"] },
        "moodle-qtype_ddimageortext-form": { "requires": ["moodle-qtype_ddimageortext-dd", "form_filepicker"] },
        "moodle-qtype_ddimageortext-dd": { "requires": ["node", "dd", "dd-drop", "dd-constrain"] },
        "moodle-qtype_ddmarker-form": { "requires": ["moodle-qtype_ddmarker-dd", "form_filepicker", "graphics", "escape"] },
        "moodle-qtype_ddmarker-dd": { "requires": ["node", "event-resize", "dd", "dd-drop", "dd-constrain", "graphics"] },
        "moodle-qtype_ddwtos-dd": { "requires": ["node", "dd", "dd-drop", "dd-constrain"] },
        "moodle-mod_assign-history": { "requires": ["node", "transition"] },
        "moodle-mod_forum-subscriptiontoggle": { "requires": ["base-base", "io-base"] },
        "moodle-mod_quiz-quizbase": { "requires": ["base", "node"] },
        "moodle-mod_quiz-questionchooser": { "requires": ["moodle-core-chooserdialogue", "moodle-mod_quiz-util", "querystring-parse"] },
        "moodle-mod_quiz-toolboxes": { "requires": ["base", "node", "event", "event-key", "io", "moodle-mod_quiz-quizbase", "moodle-mod_quiz-util-slot", "moodle-core-notification-ajaxexception"] },
        "moodle-mod_quiz-quizquestionbank": { "requires": ["base", "event", "node", "io", "io-form", "yui-later", "moodle-question-qbankmanager", "moodle-core-notification-dialogue"] },
        "moodle-mod_quiz-dragdrop": { "requires": ["base", "node", "io", "dom", "dd", "dd-scroll", "moodle-core-dragdrop", "moodle-core-notification", "moodle-mod_quiz-quizbase", "moodle-mod_quiz-util-base", "moodle-mod_quiz-util-page", "moodle-mod_quiz-util-slot", "moodle-course-util"] },
        "moodle-mod_quiz-autosave": { "requires": ["base", "node", "event", "event-valuechange", "node-event-delegate", "io-form"] },
        "moodle-mod_quiz-util": { "requires": ["node"], "use": ["moodle-mod_quiz-util-base"], "submodules": { "moodle-mod_quiz-util-base": {}, "moodle-mod_quiz-util-slot": { "requires": ["node", "moodle-mod_quiz-util-base"] }, "moodle-mod_quiz-util-page": { "requires": ["node", "moodle-mod_quiz-util-base"] } } },
        "moodle-mod_quiz-repaginate": { "requires": ["base", "event", "node", "io", "moodle-core-notification-dialogue"] },
        "moodle-mod_quiz-randomquestion": { "requires": ["base", "event", "node", "io", "moodle-core-notification-dialogue"] },
        "moodle-mod_quiz-modform": { "requires": ["base", "node", "event"] },
        "moodle-message_airnotifier-toolboxes": { "requires": ["base", "node", "io"] },
        "moodle-block_course_overview_campus-hidenews": { "requires": ["base", "node"] },
        "moodle-block_course_overview_campus-hidecourse": { "requires": ["base", "node"] },
        "moodle-block_course_overview_campus-filter": { "requires": ["base", "node"] },
        "moodle-block_navigation-navigation": { "requires": ["base", "io-base", "node", "event-synthetic", "event-delegate", "json-parse"] },
        "moodle-block_xp-filters": { "requires": ["base", "node", "moodle-core-dragdrop", "moodle-block_xp-rulepicker"] },
        "moodle-block_xp-notification": { "requires": ["base", "node", "handlebars", "button-plugin", "moodle-core-notification-dialogue"] },
        "moodle-block_xp-rulepicker": { "requires": ["base", "node", "handlebars", "moodle-core-notification-dialogue"] },
        "moodle-filter_glossary-autolinker": { "requires": ["base", "node", "io-base", "json-parse", "event-delegate", "overlay", "moodle-core-event", "moodle-core-notification-alert", "moodle-core-notification-exception", "moodle-core-notification-ajaxexception"] },
        "moodle-filter_mathjaxloader-loader": { "requires": ["moodle-core-event"] },
        "moodle-editor_atto-rangy": { "requires": [] },
        "moodle-editor_atto-editor": { "requires": ["node", "transition", "io", "overlay", "escape", "event", "event-simulate", "event-custom", "node-event-html5", "yui-throttle", "moodle-core-notification-dialogue", "moodle-core-notification-confirm", "moodle-editor_atto-rangy", "handlebars", "timers"] },
        "moodle-editor_atto-plugin": { "requires": ["node", "base", "escape", "event", "event-outside", "handlebars", "event-custom", "timers", "moodle-editor_atto-menu"] },
        "moodle-editor_atto-menu": { "requires": ["moodle-core-notification-dialogue", "node", "event", "event-custom"] },
        "moodle-report_eventlist-eventfilter": { "requires": ["base", "event", "node", "node-event-delegate", "datatable", "autocomplete", "autocomplete-filters"] },
        "moodle-report_loglive-fetchlogs": { "requires": ["base", "event", "node", "io", "node-event-delegate"] },
        "moodle-gradereport_grader-gradereporttable": { "requires": ["base", "node", "event", "handlebars", "overlay", "event-hover"] },
        "moodle-gradereport_history-userselector": { "requires": ["escape", "event-delegate", "event-key", "handlebars", "io-base", "json-parse", "moodle-core-notification-dialogue"] },
        "moodle-tool_capability-search": { "requires": ["base", "node"] },
        "moodle-tool_monitor-dropdown": { "requires": ["base", "event", "node"] },
        "moodle-assignfeedback_editpdf-editor": { "requires": ["base", "event", "node", "io", "graphics", "json", "event-move", "event-resize", "querystring-stringify-simple", "moodle-core-notification-dialog", "moodle-core-notification-exception", "moodle-core-notification-ajaxexception"] },
        "moodle-atto_accessibilitychecker-button": { "requires": ["color-base", "moodle-editor_atto-plugin"] },
        "moodle-atto_accessibilityhelper-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_align-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_bold-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_charmap-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_clear-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_collapse-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_emoticon-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_equation-button": { "requires": ["moodle-editor_atto-plugin", "moodle-core-event", "io", "event-valuechange", "tabview", "array-extras"] },
        "moodle-atto_hr-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_html-button": { "requires": ["moodle-editor_atto-plugin", "event-valuechange"] },
        "moodle-atto_image-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_indent-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_italic-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_link-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_managefiles-usedfiles": { "requires": ["node", "escape"] },
        "moodle-atto_managefiles-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_media-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_noautolink-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_orderedlist-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_rtl-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_strike-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_subscript-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_superscript-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_table-button": { "requires": ["moodle-editor_atto-plugin", "moodle-editor_atto-menu", "event", "event-valuechange"] },
        "moodle-atto_title-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_underline-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_undo-button": { "requires": ["moodle-editor_atto-plugin"] },
        "moodle-atto_unorderedlist-button": { "requires": ["moodle-editor_atto-plugin"] }
      }
    },
    "gallery": {
      "name": "gallery",
      "base": "http:\/\/moodle.hwr-berlin.de\/lib\/yuilib\/gallery\/",
      "combine": true,
      "comboBase": "http:\/\/moodle.hwr-berlin.de\/theme\/yui_combo.php?",
      "ext": false,
      "root": "gallery\/1472726786\/",
      "patterns": { "gallery-": { "group": "gallery" } }
    }
  },
  "modules": {
    "core_filepicker": {
      "name": "core_filepicker",
      "fullpath":
          "http:\/\/moodle.hwr-berlin.de\/lib\/javascript.php\/1472726786\/repository\/filepicker.js",
      "requires": [
          "base", "node", "node-event-simulate", "json", "async-queue", "io-base", "io-upload-iframe",
          "io-form", "yui2-treeview", "panel", "cookie", "datatable", "datatable-sort", "resize-plugin",
          "dd-plugin", "escape", "moodle-core_filepicker"
      ]
    },
    "mathjax": {
      "name": "mathjax",
      "fullpath": "http:\/\/cdn.mathjax.org\/mathjax\/2.5-latest\/MathJax.js?delayStartupUntil=configured"
    }
  }
};
M.yui.loader = { modules: {} };

//]]>