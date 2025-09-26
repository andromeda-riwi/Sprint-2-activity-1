// @ts-check
import { themes as prismThemes } from "prism-react-renderer";

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: "Sprint 2 - User Management System",
  tagline: "Console-based user management system in C# / .NET 8 with MySQL",
  favicon: "img/favicon.ico",

  // Your GitHub repo
  url: "https://andromeda-riwi.github.io",
  baseUrl: "/Sprint_2/",

  // GitHub pages deployment config.
  organizationName: "andromeda-riwi", // GitHub org/user name
  projectName: "Sprint_2", // Repo name
  deploymentBranch: "gh-pages",

  onBrokenLinks: "throw",
  onBrokenMarkdownLinks: "warn",

  i18n: {
    defaultLocale: "en",
    locales: ["en"],
  },

  presets: [
    [
      "classic",
      {
        docs: {
          sidebarPath: "./sidebars.js",
          editUrl: "https://github.com/andromeda-riwi/Sprint_2/tree/main/docs/",
        },
        blog: false, // Disable blog if not needed
        theme: {
          customCss: "./src/css/custom.css",
        },
      },
    ],
  ],

  themeConfig: {
    navbar: {
      title: "Sprint 2",
      logo: {
        alt: "Sprint 2 Logo",
        src: "img/logo.svg", // You can add your own logo here
      },
      items: [
        {
          type: "docSidebar",
          sidebarId: "tutorialSidebar",
          position: "left",
          label: "Docs",
        },
        {
          href: "https://github.com/andromeda-riwi/Sprint_2",
          label: "GitHub",
          position: "right",
        },
      ],
    },
    footer: {
      style: "dark",
      links: [
        {
          title: "Docs",
          items: [
            {
              label: "Introduction",
              to: "/docs/intro",
            },
          ],
        },
        {
          title: "Community",
          items: [
            {
              label: "GitHub",
              href: "https://github.com/andromeda-riwi/Sprint_2",
            },
          ],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()} Andromeda Riwi. Built with Docusaurus.`,
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
    },
  },
};

export default config;
