import requests
import json

# Liste deiner Repositories
REPOS = [
    {
        "owner": "miriki",
        "repo": "TI99_Tools",
        "exe": "TI99_Char_Tools.exe",
        "tag_prefix": "char",
        "description": "Tool for TI-99/4A character sets"
    },
    {
        "owner": "miriki",
        "repo": "TI99_Tools",
        "exe": "TI99_Disk_Tools.exe",
        "tag_prefix": "disk",
        "description": "Tool for TI-99/4A disk-images"
    }
]

def get_latest_release(owner, repo):
    url = f"https://api.github.com/repos/{owner}/{repo}/releases/latest"
    print( url )
    response = requests.get(url)
    if response.status_code == 200:
        print( "ok" )
        data = response.json()
        return {
            "version": data["tag_name"],
            "published_at": data["published_at"],
            "download_url": data["assets"][0]["browser_download_url"] if data["assets"] else None
        }
    else:
        print( "fail" )
        return {
            "version": "n/a",
            "published_at": None,
            "download_url": None
        }

def build_dashboard_data():
    dashboard = []
    for repo in REPOS:
        release = get_latest_release(repo["owner"], repo["repo"])
        dashboard.append({
            "name": repo["repo"],
            "version": release["version"],
            "published": release["published_at"],
            "download": release["download_url"],
            "exe": repo["exe"],
            "tag_prefix": repo["tag_prefix"],
            "description": repo["description"]
        })
    return dashboard

if __name__ == "__main__":
    data = build_dashboard_data()
    with open("dashboard.json", "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2)
    print("✅ dashboard.json wurde erstellt.")
