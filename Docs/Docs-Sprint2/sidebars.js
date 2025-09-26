// @ts-check

// This runs in Node.js - Don't use client-side code here (browser APIs, JSX...)

/**
 * Creating a sidebar enables you to:
 - create an ordered group of docs
 - render a sidebar for each doc of that group
 - provide next/previous navigation

 The sidebars can be generated from the filesystem, or explicitly defined here.

 Create as many sidebars as you want.

 @type {import('@docusaurus/plugin-content-docs').SidebarsConfig}
 */
const sidebars = {
  // By default, Docusaurus generates a sidebar from the docs folder structure
  
  // But you can create a sidebar manually
  tutorialSidebar: [
    {
      type: 'doc',
      id: 'intro', // intro.md
      label: 'Introduction',
    },
    {
      type: 'doc',
      id: 'install', // install.md
      label: 'Installation & Setup',
    },
    {
      type: 'doc',
      id: 'usage', // usage.md
      label: 'Usage Guide',
    },
    {
      type: 'doc',
      id: 'architecture', // architecture.md
      label: 'Architecture',
    },
    {
      type: 'doc',
      id: 'database', // database.md
      label: 'Database Model',
    },
    {
      type: 'doc',
      id: 'contribute', // contribute.md
      label: 'Contributing',
    },
    {
      type: 'doc',
      id: 'appendix', // appendix.md
      label: 'Appendix',
    },
  ],
};

export default sidebars;
