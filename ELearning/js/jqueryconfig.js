//<![CDATA[
var require = {
  baseUrl: 'http://moodle.hwr-berlin.de/lib/requirejs.php/1472726786/',
  // We only support AMD modules with an explicit define() statement.
  enforceDefine: true,
  skipDataMain: true,

  paths: {
    jquery: 'http://moodle.hwr-berlin.de/lib/javascript.php/1472726786/lib/jquery/jquery-1.11.3.min',
    jqueryui: 'http://moodle.hwr-berlin.de/lib/javascript.php/1472726786/lib/jquery/ui-1.11.4/jquery-ui.min',
    jqueryprivate: 'http://moodle.hwr-berlin.de/lib/javascript.php/1472726786/lib/requirejs/jquery-private'
  },

  // Custom jquery config map.
  map: {
    // '*' means all modules will get 'jqueryprivate'
    // for their 'jquery' dependency.
    '*': { jquery: 'jqueryprivate' },

    // 'jquery-private' wants the real jQuery module
    // though. If this line was not here, there would
    // be an unresolvable cyclic dependency.
    jqueryprivate: { jquery: 'jquery' }
  }
};

//]]>