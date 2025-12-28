const config = {
  name: 'systemAdmin',
  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },
  shared: {
    '@angular/core': { singleton: true, strictVersion: true, requiredVersion: 'auto' },
    '@angular/common': { singleton: true, strictVersion: true, requiredVersion: 'auto' },
    '@angular/common/http': { singleton: true, strictVersion: true, requiredVersion: 'auto' },
    '@angular/router': { singleton: true, strictVersion: true, requiredVersion: 'auto' },
    'rxjs': { singleton: true, strictVersion: false, requiredVersion: 'auto' }
  },
};

/**
 * Nx requires a default export of the config to allow correct resolution of the module federation graph.
 **/
export default config;
