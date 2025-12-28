import { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'shell',
  /**
   * To use a remote that does not exist in your current Nx Workspace
   * You can use the tuple-syntax to define your remote
   *
   * remotes: [['my-external-remote', 'https://nx-angular-remote.netlify.app']]
   *
   * You _may_ need to add a `remotes.d.ts` file to your `src/` folder declaring the external remote for tsc, with the
   * following content:
   *
   * declare module 'my-external-remote';
   *
   */
  remotes: [
    ['systemAdmin', 'https://note-system-admin.vercel.app/remoteEntry.mjs']
  ],

  shared: (name, config) => {
    const sharedLibraries = [
      '@angular/core',
      '@angular/common',
      '@angular/common/http',
      '@angular/router',
      'rxjs'
    ];

    if (sharedLibraries.includes(name)) {
      return {
        singleton: true,
        strictVersion: name !== 'rxjs',
      };
    }
    return config;
  },

};
/**
 * Nx requires a default export of the config to allow correct resolution of the module federation graph.
 **/
export default config;
