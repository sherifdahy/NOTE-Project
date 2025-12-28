import { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'admin',
  exposes: {
    './Module': 'apps/admin/src/app/remote-entry/entry-module.ts',
  },
};

export default config;
