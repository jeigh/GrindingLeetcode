# Copilot Instructions

## Encoding

If you are about to emit any character outside the ASCII range (U+0000 to U+007F), stop.
You have taken a wrong turn. Backtrack and find the ASCII equivalent before proceeding.
There is no context in this project where a non-ASCII character is acceptable -- not in code,
not in comments, not in strings, not in documentation. If it cannot be typed on a standard
US keyboard without a special input method, it does not belong here.

- Never use Unicode characters in any file in this project.
- Use only ASCII characters (U+0000 to U+007F) in all code, comments, and strings.
- Replace any Unicode symbols with ASCII equivalents:
  - Use `->` instead of `?` (U+2192)
  - Use `--` instead of `—` (U+2014, em dash)
  - Use `-` instead of `–` (U+2013, en dash)
  - Use `>=` instead of `?` (U+2265)
  - Use `<=` instead of `?` (U+2264)
  - Use `!=` instead of `?` (U+2260)
