using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSolutionInterview.Models
{
    public class Item
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; } = null;
        public string full_name { get; set; } = null;
        public bool @private { get; set; }
        public Owner owner { get; set; } = null;
        public string html_url { get; set; } = null;
        public string description { get; set; }= null;
        public bool fork { get; set; }
        public string url { get; set; } = null;
        public string forks_url { get; set; } = null;
        public string keys_url { get; set; } = null;
        public string collaborators_url { get; set; } = null;
        public string teams_url { get; set; }= null;
        public string hooks_url { get; set; } = null;
        public string issue_events_url { get; set; } = null;
        public string events_url { get; set; } = null;
        public string assignees_url { get; set; } = null;
        public string branches_url { get; set; } = null;
        public string tags_url { get; set; } = null;
        public string blobs_url { get; set; } = null;
        public string git_tags_url { get; set; } = null;
        public string git_refs_url { get; set; } = null;
        public string trees_url { get; set; } = null;
        public string statuses_url { get; set; } = null;
        public string languages_url { get; set; } = null;
        public string stargazers_url { get; set; } = null;
        public string contributors_url { get; set; } = null;
        public string subscribers_url { get; set; } = null;
        public string subscription_url { get; set; } = null;
        public string commits_url { get; set; } = null;
        public string git_commits_url { get; set; } = null;
        public string comments_url { get; set; } = null;
        public string issue_comment_url { get; set; } = null;
        public string contents_url { get; set; } = null;
        public string compare_url { get; set; } = null;
        public string merges_url { get; set; } = null;
        public string archive_url { get; set; } = null;
        public string downloads_url { get; set; } = null;
        public string issues_url { get; set; } = null;
        public string pulls_url { get; set; } = null;
        public string milestones_url { get; set; } = null;
        public string notifications_url { get; set; } = null;
        public string labels_url { get; set; } = null;
        public string releases_url { get; set; } = null;
        public string deployments_url { get; set; } = null;
        public DateTime? created_at { get; set; } 
        public DateTime? updated_at { get; set; }
        public DateTime? pushed_at { get; set; }
        public string git_url { get; set; }= null;
        public string ssh_url { get; set; }= null;
        public string clone_url { get; set; }= null;
        public string svn_url { get; set; }= null;
        public string homepage { get; set; }= null;
        public int size { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public string language { get; set; }= null;
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_downloads { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public bool has_discussions { get; set; }
        public int forks_count { get; set; }
        public object mirror_url { get; set; } = null;
        public bool archived { get; set; }
        public bool disabled { get; set; }
        public int open_issues_count { get; set; }
        public License license { get; set; }=null;
        public bool allow_forking { get; set; }
        public bool is_template { get; set; }
        public bool web_commit_signoff_required { get; set; }
        public List<string> topics { get; set; }=null;
        public string visibility { get; set; } = null;
        public int forks { get; set; }
        public int open_issues { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; } = null;
        public double score { get; set; }
    }
}